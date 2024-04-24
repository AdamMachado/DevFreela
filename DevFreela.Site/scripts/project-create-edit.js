window.onload = function (){
    // Typo: 'create' ou 'edit'
    const  screenType = 'create';

    // MODO CRIAR
    if(screenType == 'create'){
        document.querySelector('#main-title').innerHTML = "Vamos cadastrar seu novo projeto";
        document.querySelector('#action-button').innerHTML = "Cadastrar";

    }
    // MODO EDITAR
    if(screenType == 'editar'){
        document.querySelector('#main-title').innerHTML = "Editar projeto";
        document.querySelector('#action-button').innerHTML = "Salvar";
    }
}