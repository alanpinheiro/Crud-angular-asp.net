


//define aplicação angular e o controller
var app = angular.module("produtosApp", []);

//registra o controller e cria a função para obter os dados do Controlador MVC
app.controller("produtosCtrl", function ($scope, $http) {

    //////////////////////////////////////////
    // lista alunos assim que  aplicacao inicia
    $http.get('/home/GetAlunos/')
    .success(function (result) {
        //$scope.produtos = result;
        $scope.alunos = result;
    })
    .error(function (data) {
        console.log(data);
    });



    //////////////////////////////////////////////////////////
    //chama o  método IncluirAlunos do controlador
    $scope.Addalunos = function (alunos) {

        
        $http.post('/home/IncluirAlunos/', { novoAluno: alunos })
        .success(function (result) {
            $scope.alunos = result;
            
            $scope.showme = false;

            
            //limpando os inputs 
            $scope.empInfo.nome = "";
            $scope.empInfo.email = "";
            $scope.empInfo.sexo = "";

            
            

        })
        .error(function (data) {
            console.log(data);
        });
    }


    ///////////////////////////////////////////////////////
    //chama o  método ExcluirAlunor
    $scope.DeletaAluno = function (alunos) {

       
        $http.post('/home/ExcluirAluno/', { excluirAluno: alunos })
        .success(function (result) {
            $scope.alunos = result;
           

        })
        .error(function (data) {
            console.log(data);
        });

    }



    ///////////////////////////////////////////////////////
    //chama o  método ExcluirAlunor
    $scope.Editar = function (alunos) {

        
        $scope.showEdit = true;
        $scope.currentUser = alunos;
        

    }


    ///////////////////////////////////////////////////////
    //chama o  método ExcluirAlunor
    $scope.AlterarAluno = function (alunos) {

     
        $http.post('/home/AlterarAluno/', { alterarAluno: alunos })
        .success(function (result) {
            $scope.alunos = result;
            $scope.showEdit = false;

        })
        .error(function (data) {
            console.log(data);
        });

    }





});//fim do controller





