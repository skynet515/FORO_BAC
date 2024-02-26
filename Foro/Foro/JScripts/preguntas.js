$(document).ready(function () {
    var session = $("#idUsuario").val();
    $("#btnGuardarPregunta").on("click", function () {
        fnAgregarPregunta();
    });

    fnListarPreguntas(session);
});

function fnListarPreguntas(session) {

    var urlQuerys = $("#urlquerys").val();
    var idRol = $("#idRol").val();

    if (session != null) {
        $.ajax({
            url: urlQuerys + "Preguntas/ListaPreguntas",
            type: "GET",
            success: function (data) {
                var oTable = $('#tblPreguntas').DataTable();
                oTable.clear();

                for (var i = 0; i < data.length; i++) {
                    var s = '';
                    var button = '<div class="btn-group">' +
                        '<button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Acciones</button>';
                    button += '<div class="dropdown-menu">';



                    if (data[i].activo) {
                        button += '<a class="dropdown-item hand ResponderPregunta" o href="/Home/Respuestas/' + parseInt(data[i].idPregunta) + '"><i class="fas fa-question mr-2"></i> Responder Pregunta</a>';
                        if (data[i].idUsuario == session) {

                            button += '<a class="dropdown-item hand Cerrar" data-idpregunta="' + parseInt(data[i].idPregunta) + '" onclick="fnCerrarPregunta(' + parseInt(data[i].idPregunta) + ')"><i class="fa fa-trash"></i> Cerrar Pregunta</a>';

                        }
                    }


                    s += '<tr>';
                    s += '<td>' + data[i].idPregunta + '</td>';
                    s += '<td>' + data[i].pregunta + '</td>';
                    s += '<td>' + data[i].nombreUsuario + '</td>';
                    s += '<td>' + button + '</td>';
                    s += '<tr>';
                    const tr = $(s);
                    oTable.row.add(tr[0]).draw();

                }




            }

        })
    }


}

function fnAgregarPregunta() {

    var pregunta = $("#txtPregunta").val();
    var urlCmd = $("#urlcommand").val();
    var url = $("#hdnUrlUs").val();


    if (fnValidarAgregarPregunta()) {
        $.ajax({
            url: urlCmd + "PreguntasCMD/InsertarPregunta",
            type: "POST",
            dataType: 'JSON',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                idUsuario: $("#hdnIdUsuario").val(),
                pregunta: pregunta
            }),
            beforeSend: function () {
                Procesando();
            },
            success: function (data) {
                DesbloquearUI();
                if (data.message) {
                    MensajeDeExito("Exito", "Pregunta Agregada Exitosamente", url + "Home/Index")
                } else {
                    MensajeDeError("Ups!, ocurrio un error");
                }
            }, error: function () {
                DesbloquearUI();
                MensajeDeError("Ups!, ocurrio un error");
            }
        });
    }

}

function fnCerrarPregunta(idPregunta) {
    var urlCmd = $("#urlcommand").val();
    var url = $("#hdnUrlUs").val();

    $.ajax({
        url: urlCmd + "PreguntasCMD/CerrarPregunta",
        type: "POST",
        dataType: 'JSON',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify({
            idPregunta: idPregunta
        }),
        beforeSend: function () {
            Procesando();
        },
        success: function (data) {
            DesbloquearUI();
            if (data.message) {
                MensajeDeExito("Exito", "Pregunta Cerrada Exitosamente", url + "Home/Index")
            } else {
                MensajeDeError("Ups!, ocurrio un error");
            }
        }, error: function () {
            DesbloquearUI();
            MensajeDeError("Ups!, ocurrio un error");
        }
    });


}
