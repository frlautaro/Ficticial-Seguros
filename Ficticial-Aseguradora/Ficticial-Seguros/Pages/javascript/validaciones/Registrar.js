
function validarNombre() {
    var nombre = document.getElementById('<%=txtNombre.ClientID %>').value;
    var regex = /^[a-zA-Z\s]*$/;
    if (!regex.test(nombre)) {
        alert('Por favor, ingrese solo letras en el campo Nombre.');
        return false;
    }
    return true;
}

function validarIdentificacion() {
    var identificacion = document.getElementById('<%=txtIdentificacion.ClientID %>').value;
    var regex = /^[0-9]*$/;
    if (!regex.test(identificacion)) {
        alert('Por favor, ingrese solo números en el campo Identificación.');
        return false;
    }
    return true;
}


function validarContrasenia() {
    var contrasenia = document.getElementById('<%=txtContrasenia.ClientID %>').value;

    // Verificar si la contraseña tiene al menos 8 caracteres, una mayúscula, una minúscula y un número
    var regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;

    if (!regex.test(contrasenia)) {
        alert('La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula y un número.');
        return false;
    }
    return true;
}



function validarEdad() {
    var edad = document.getElementById('<%=txtEdad.ClientID %>').value;
    var regex = /^[0-9]*$/;
    if (!regex.test(edad)) {
        alert('Por favor, ingrese solo números en el campo Edad.');
        return false;
    }
    return true;
}

function validarEnfermedad() {
    var enfermedad = document.getElementById('<%=txtEnfermedad.ClientID %>').value;
    var regex = /^[a-zA-Z\s]*$/;
    if (!regex.test(enfermedad)) {
        alert('Por favor, ingrese solo letras en el campo Enfermedad.');
        return false;
    }
    return true;
}

function validarRadioButton() {
    var rbEstado = document.getElementById('<%=rbEstado.ClientID %>');
    var rbManeja = document.getElementById('<%=rbManeja.ClientID %>');
    var rbDiabetico = document.getElementById('<%=rbDiabetico.ClientID %>');
    var rbLentes = document.getElementById('<%=rbLentes.ClientID %>');

    if (!(rbEstado.checked || rbManeja.checked || rbDiabetico.checked || rbLentes.checked)) {
        alert('Por favor, seleccione un valor para los campos Estado, Maneja, Diabético y Lentes.');
        return false;
    }
    return true;
}

function validarFormulario() {
    return validarNombre() && validarIdentificacion() && validarEdad() && validarRadioButton() && (document.getElementById('<%=txtEnfermedad.ClientID %>').style.display == 'none' || validarEnfermedad());
}
