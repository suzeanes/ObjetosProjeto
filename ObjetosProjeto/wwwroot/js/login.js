(function () {
    'use strict';

    angular
        .module('app')
        .factory('login', login);

    login.$inject = ['$http'];

    function login($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() { }
    }
})();
let elementLogin =
    document.getElementById("login");
let elementSenha =
    document.getElementById("senha");

const verificarLogin = (login, senha) => {
    if (login == "su" && senha == "123") {
        localStorage.setItem("usuarioLogado", "Suzeane");
        localStorage.setItem("sobrenomeUsuarioLogado", "Stuart");
        return true;
    }
    return false;
};

const apresentaMensagemErro = () => {
    alert("Usuário inexistente ou senha incorreta!!!");
};
const realizarLogin = () => {
    const login = elementLogin.value;
    const senha = elementSenha.value;
    if (verificarLogin(login, senha)) {
        //window.location.href = "./views/home.html";
        window.location.assign("./index.html");
    } else {
        apresentaMensagemErro();
    }

};