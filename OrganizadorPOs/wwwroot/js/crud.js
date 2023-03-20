const organizarPorNumero = (e) => {
    const type = $(e).attr('id');
    let elements = [];

    $('td.' + type).each(function () {
        const element = $(this).html();
        elements.push(element);
    });

    let chaveOrganizadora = false;
    const retornoLocal = localStorage.getItem('chaveOrganizadora');

    if (retornoLocal == null)
        chaveOrganizadora = true;
    else
        chaveOrganizadora = 'true' === retornoLocal

    localStorage.setItem('chaveOrganizadora', !chaveOrganizadora)

    elements = elements.map((x, i) => {
        let stringNumber = ''

        if (!!x)
            stringNumber = x.slice(6)
        else
            stringNumber = '0'

        return {
            position: i, number: parseInt(stringNumber)
        }
    });

    if (!chaveOrganizadora)
        elements = elements.sort((a, b) => a.number - b.number);
    else
        elements = elements.sort((a, b) => b.number - a.number);

    const rows = $('tr.tr-dinamica');

    elements.forEach(x => {
        $('tbody#tbdy').append(rows[x.position]);
    })
};

const organizarPorData = (e) => {
    const type = $(e).attr('id');
    let elements = [];

    $('td.' + type).each(function () {
        const element = $(this).html();
        elements.push(element);
    });

    let chaveOrganizadora = false;
    const retornoLocal = localStorage.getItem('chaveOrganizadora');

    if (retornoLocal == null)
        chaveOrganizadora = true;
    else
        chaveOrganizadora = 'true' === retornoLocal

    localStorage.setItem('chaveOrganizadora', !chaveOrganizadora)

    elements = elements.map((x, i) => {
        const day = x.slice(0, 2);
        const month = x.slice(3, 5)
        const year = x.slice(6)

        let utcDate = '';
        if (!!day)
            utcDate = year + '-' + month + '-' + day + 'T00:00:00Z'
        else
            utcDate = '2001-01-01T00:00:00Z'

        return {
            position: i,
            number: new Date(utcDate)
        }
    });

    if (!chaveOrganizadora)
        elements = elements.sort((a, b) => a.number - b.number);
    else
        elements = elements.sort((a, b) => b.number - a.number);

    const rows = $('tr.tr-dinamica');

    elements.forEach(x => {
        $('tbody#tbdy').append(rows[x.position]);
    })
};

const ativarSelecao = () => {

    const checkboxesNaoVisiveis = $('#headerColunaSelecionar').hasClass('invisible-checkbox');

    if (checkboxesNaoVisiveis) {
        $('.colunaSelecionar').removeClass('invisible-checkbox');
        $('#botao-excel').addClass('invisible-checkbox');
    }
    else {
        $('input:checkbox').prop('checked', false);
        $('.colunaSelecionar').addClass('invisible-checkbox');
        $('#botao-excel').removeClass('invisible-checkbox');
    }

}

const excluirEmMassa = () => {
    const idsExclusao = [];

    $("input:checkbox:checked").each(function () {
        const e = $(this).val()
        if (e != "0")
            idsExclusao.push(e);
    });

    const json = { value: idsExclusao.map(x => parseInt(x)) }

    $.ajax({
        type: 'POST',
        url: '/Home/DesativarAtivarEmMassa',
        datatype: 'json',
        data: json,
        success: function (result) {
            const retorno = JSON.parse(result);

            if (retorno.status !== 1)
                alert('Não foi possivel executar essa ação')

            location.href = '/Home'
        },
        error: function (ex) {
            alert(ex);
        }
    });
}

const marcarDesmarcarTudo = (e) => {
    $('input:checkbox').not(e).prop('checked', e.checked);
}

const submitPersonalizado = () => {
    $('#gerar-excel').val(undefined);
    $('form').submit();
}

const baixarExcel = () => {
    $('#gerar-excel').val(true);
    $('form').submit();
}