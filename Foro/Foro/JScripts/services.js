﻿$(document).ready(function () {
    var session = [];
    $("#btnIngresarLogin").on("click", function () {
        var urlQuerys = $("#urlquerys").val();
        var url = $("#hdnUrlUs").val();

        if (fnValidarCamposLoging()) {

            $.ajax({
                url: urlQuerys + "Usuario/Login",
                type: "POST",
                dataType: 'JSON',
                contentType: 'application/json',
                data: JSON.stringify({
                    nombreUsuario: $("#txtUsuario").val(),
                    clave: $("#txtClave").val()
                }),
                beforeSend: function () {
                    Procesando()
                }, success: function (data) {
                    DesbloquearUI();
                    if (data != null) {
                        //fnGrabarSesion(data.success.idUsuario);
                        session = data;
                        $.ajax({
                            url: url + "Usuario/GrabarSesion",
                            type: "POST",
                            dataType: "JSON",
                            contentType: 'application/json',
                            dataType: 'json',
                            data: JSON.stringify({
                                usuario: session
                            }),
                            success: function (data) {
                                if (data.request) {
                                    NotificacionSimple("Bienvenido", "Esta cargando su espacio de trabajo", "2000", url + "Home/Index");
                                } else {
                                    MensajeDeError("Ha ocurrido un Error");
                                }
                            }
                        });


                    } else {
                        MensajeDeError("Usuario o contraseña Incorrecta");
                    }
                }, error: function () {
                    DesbloquearUI();
                    MensajeDeError("Ha ocurrido un Error");
                }
            });
        }



    });
    //Se obtiene el listado de las preguntas
    //fnListarPreguntas(session)

    $("#btnCrearUsuario").click(function () {
        var urlCmd = $("#urlcommand").val();
        var url = $("#hdnUrlUs").val();

        if (fnValidarCamposLoging()) {

            $.ajax({
                url: urlCmd + "UsuarioCMD/InsertarUsuario",
                type: "POST",
                dataType: 'JSON',
                contentType: 'application/json',
                dataType: 'json',
                data: JSON.stringify({
                    nombreUsuario: $("#txtUsuario").val(),
                    clave: $("#txtClave").val()
                }),
                beforeSend: function () {
                    Procesando()
                }, success: function (data) {
                    DesbloquearUI();
                    if (data.message == "OK") {
                        MensajeDeExito("Exito", "Usuario Registrado", url);
                    } else if (data.message == "DUPLICATE") {
                        MensajeDeError("Usuario Existente");
                    } else {
                        MensajeDeError("Ha ocurrido un error");
                    }
                }, error: function () {
                    DesbloquearUI();
                    MensajeDeError("Ha ocurrido un Error");
                }
            });
        }
    });


});



function fnIniciarSesion() {



}


//function fnListarPreguntas(session) {

//    var baseUrl = $("#hdnBaseUrl").val();
//    var idRol = $("#idRol").val();

//    if (session != null) {
//        $.ajax({
//            url: baseUrl + "ForoBACApi/ListarPreguntas",
//            type: "POST",
//            success: function (data) {
//                var oTable = $('#tblPreguntas').DataTable();
//                oTable.clear();

//                for (var i = 0; i < data.length; i++) {
//                    var s = '';
//                    var button = '<div class="btn-group">' +
//                        '<button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Acciones</button>';
//                    button += '<div class="dropdown-menu">';

//                    if (idRol == 1) {
//                        button += '<a class="dropdown-item hand CerrarPregunta"><i class="fas fa-times mr-2"></i> Cerrar Pregunta</a>';
//                    } else {
//                        button += '<a class="dropdown-item hand ResponderPregunta" o href="/Home/Respuestas/' + parseInt(data[i].idPregunta) + '"><i class="fas fa-question mr-2"></i> Responder Pregunta</a>';
//                    }

//                    s += '<tr>';
//                    s += '<td>' + data[i].idPregunta + '</td>';
//                    s += '<td>' + data[i].pregunta + '</td>';
//                    s += '<td>' + data[i].nombreUsuario + '</td>';
//                    s += '<td>'+button+'</td>';
//                    s += '<tr>';
//                    const tr = $(s);
//                    oTable.row.add(tr[0]).draw();

//                }




//            }

//        })
//    }


//}





function fnGrabarSesion(idUsuario) {
    return idUsuario;
}

