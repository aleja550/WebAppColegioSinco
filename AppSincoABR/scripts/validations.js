function LoginValidate() {
    var usuario, clave;

    usuario = document.getElementById("txtUsuario").value;
    clave = document.getElementById("txtClave").value;

    if (usuario == "" || clave == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }
    return true;
}


function crearuserValidate() {
    var Cedula, TipoUser, Nombre, Apellido, Usuario, Clave;

    Cedula = document.getElementById("ContentD_Cedulatxt").value;
    TipoUser = document.getElementById("ContentD_DdlUserType").value;
    Nombre = document.getElementById("ContentD_Nombrestxt").value;
    Apellido = document.getElementById("ContentD_Apellidostxt").value;
    Usuario = document.getElementById("ContentD_Usuariotxt").value;
    Clave = document.getElementById("ContentD_Clavetxt").value;
    expresionregusuario = /[A-Za-z0-9]$/;

    if (Cedula == 0 || TipoUser == "Select" || Nombre == "" || Apellido == "" || Usuario == "" || Clave == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }

    else if (Nombre.length > 20 || Apellido.length > 20 || Usuario.length > 20 || Clave.length > 20) {
        alert("Los campos pueden tener hasta 20 carácteres");
        return false;
    }
    else if (!expresionregusuario.test(Usuario.trim())) {
        alert("No se admiten carácteres especiales en el campo Usuario.");
        return false
    }
    return true;

}

function edituserValid() {
    var TipoUser, Nombre, Apellido, Clave;

    TipoUser = document.getElementById("ContentD_DdlUserType").value;
    Nombre = document.getElementById("ContentD_txtNombre").value;
    Apellido = document.getElementById("ContentD_txtApellido").value;
    Clave = document.getElementById("ContentD_txtPass").value;

    if (TipoUser == "Select" || Nombre == "" || Apellido == "" || Clave == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }

    else if (Nombre.length > 20 || Apellido.length > 20 || Clave.length > 20) {
        alert("Los campos solo pueden tener hasta 20 carácteres");
        return false;
    }

    return true;
}

function materiaValid() {
    var materia = document.getElementById("ContentD_Materiatxt").value;

    if (materia == "") {
        alert("Todos los campos son obligatorios");
        return false;
    }

    else if (materia.length > 25) {
        alert("Los campos solo pueden tener hasta 25 carácteres");
        return false;
    }
    return true;
}





