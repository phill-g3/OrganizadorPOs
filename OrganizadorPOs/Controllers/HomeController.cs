using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OrganizadorPOs.Domain.Entities;
using OrganizadorPOs.Domain.Interfaces;
using OrganizadorPOs.Models;
using OrganizadorPOs.ViewModels;
using System.Diagnostics;

namespace OrganizadorPOs.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRegistroService _registroService;
        private readonly IMapper _mapper;

        public HomeController(IRegistroService registroService, IMapper mapper)
        {
            _registroService = registroService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index
            (
                bool? status, bool? pagamento, bool? nf, bool? ativadoDesativado,
                DateTime? feitoEmMin, DateTime? feitoEmMax, DateTime? recebidaEmMin,
                DateTime? recebidaEmMax, string? projeto, string? tipo, bool? gerarExcel

            )
        {
            HomeViewModel model = new();

            try
            {
                FiltroRegistros filtro = new()
                {
                    Status = status,
                    Pagamento = pagamento,
                    Nf = nf,
                    AtivadoDesativado = ativadoDesativado,
                    FeitoEmMin = feitoEmMin,
                    FeitoEmMax = feitoEmMax,
                    RecebidaEmMin = recebidaEmMin,
                    RecebidaEmMax = recebidaEmMax,
                    Projeto = projeto,
                    Tipo = tipo
                };

                Task task = MontarMenus(filtro);

                List<Registro> registros = await _registroService.List(filtro);
                List<Tipo> tipos = await _registroService.ListarTipos();

                if (gerarExcel != null && (bool)gerarExcel)
                {
                    byte[] output = await _registroService.GerarExcel(registros);
                    return File(
                        output,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Controle.xlsx"
                        );
                }

                model.Registros = _mapper.Map<List<RegistroViewModel>>(registros);
                model.Filtro = _mapper.Map<FiltroRegistrosViewModel>(filtro);

                ViewBag.Tipos = tipos.Select(x => x.Nome);

                await task;

                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> AdicionarEditar(int id)
        {
            try
            {
                RegistroViewModel model = new();

                Registro? registro = await _registroService.ObterPorId(id);
                List<Tipo> tipos = await _registroService.ListarTipos();

                if (registro != null)
                    model = _mapper.Map<RegistroViewModel>(registro);

                ViewBag.Tipos = tipos.Select(x => x.Nome);

                return View(model);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEditar(RegistroViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Registro registro = _mapper.Map<Registro>(model);

                    await _registroService.AdicionarAtualizar(registro);

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DesativarAtivar(int id)
        {
            try
            {
                await _registroService.AtivarDesativar(id);
            }
            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> DesativarAtivarEmMassa(Dictionary<string, List<int>> input)
        {
            try
            {
                var ids = input["value"];

                if (ids != null && ids.Any())
                {
                    await _registroService.AtivarDesativarEmMassa(ids);
                    return Json(JsonConvert.SerializeObject(new { status = 1 }));
                }

                return Json(JsonConvert.SerializeObject(new { status = 0 }));
            }
            catch (Exception ex)
            {
                return Json(JsonConvert.SerializeObject(new { status = 0 }));
            }
        }

        private async Task MontarMenus(FiltroRegistros filtro)
        {
            if (filtro != null && filtro != null)
            {
                Dictionary<string, string?> options = new Dictionary<string, string?>()
                {
                    {"", null },
                    {"OK", "true"},
                    {"Pendente", "false"}
                };

                Dictionary<string, string> optionsAtivadoDesativado = new Dictionary<string, string>()
                {
                    {"Ativados", "true"},
                    {"Todos", "false"}
                };

                ViewBag.StatusOptions = options.Select(x => new SelectListItem()
                {
                    Text = x.Key,
                    Value = x.Value,
                    Selected = filtro.Status == (x.Value == null ? null : bool.Parse(x.Value))
                });

                ViewBag.NfOptions = options.Select(x => new SelectListItem()
                {
                    Text = x.Key,
                    Value = x.Value,
                    Selected = filtro.Nf == (x.Value == null ? null : bool.Parse(x.Value))
                });

                ViewBag.PagamentoOptions = options.Select(x => new SelectListItem()
                {
                    Text = x.Key,
                    Value = x.Value,
                    Selected = filtro.Pagamento == (x.Value == null ? null : bool.Parse(x.Value))
                });

                ViewBag.AtivadoDesativadoOptions = optionsAtivadoDesativado.Select(x => new SelectListItem()
                {
                    Text = x.Key,
                    Value = x.Value,
                    Selected = filtro.AtivadoDesativado == bool.Parse(x.Value)
                });
            }

            await Task.FromResult(Task.CompletedTask);
        }

    }
}