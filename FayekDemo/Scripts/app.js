angular.module('App', ['angularUtils.directives.dirPagination', 'angularMoment', 'ui.bootstrap','ngRoute'])
       .config(function($routeProvider){
           $routeProvider
               .when('/',{
                   templateUrl:'/Pages/index.html',
                   controller: 'Ctrl'
               })
              .when('/consultants',{
                  templateUrl:'/Pages/consultants.html',
                  controller: 'Ctrl'
              })
               .when('/consultants/create',{
                   templateUrl:'/Pages/addConsultant.html',
                   controller: 'Ctrl'
               })
               .when('/consultants/:id/edit',{
                   templateUrl:'/Pages/editConsultant.html',
                   controller: 'Ctrl'
               })
           .when('/consultants/:cons/delete', {
               templateUrl: '/Pages/deleteConsultant.html',
               controller: 'Ctrl'
           })
       })
    //Formating Dates With Moment.js
    .filter('moment', function () {
        return function (dateString) {
            //var locale = window.navigator.userLanguage || window.navigator.language;
            locale = moment.locale('sv');
            return moment(dateString).format('LLL');
        }
    })
   .controller('Ctrl', function ($scope, $http, $routeParams,$route) {
       $scope.id = $routeParams.id;
       $scope.newAssignment = {};
       $scope.msg = "";
       //$scope.selectedConsultant = {};
       //Variables
       $scope.sortColumn = "AssignmentName";
       $scope.sortReverse = false;
       //Sorting Columns
       $scope.sortData = function (column) {
           $scope.sortReverse = (column == $scope.sortColumn) ? !$scope.sortReverse : false;
           $scope.sortColumn = column;
       }

       $scope.sameColumn = function (column) {
           return (column == $scope.sortColumn) ? true : false;

       };

       //Filtering By Client Name
       $scope.search = function (myTerm, myArray) {
           if ($scope.term == undefined) {
               return true;
           }
           else {
               if (myTerm.ClientName.toLocaleLowerCase().startsWith($scope.term.toString().toLocaleLowerCase())) {
                   return true;
               }
           }
           return false;
       }

       //Get Assignments Details
       $http.get("/api/Home/GetAssignmentView").success(function (data) {
           $scope.assignmentView = data;
       }).error(function (data, status, headers, config) {
          
       })

       //Create Assignment
       $scope.CreateAssignment = function () {
           var res = $http.post("/api/Home/CreateAssignment", $scope.newAssignment);
           res.success(function (data, status, headers, config) {
               $scope.message = data;
               $scope.msg = "Assignment has been created";

           });
           res.error(function (data, status, headers, config) {
               alert("failure message: " + JSON.stringify({ data: data }));
           });
       }

       //Get All Consultants
       $http.get("/api/Home/GetConsultants").success(function (data) {
           $scope.consultants = data;
       }).error(function (data, status, headers, config) {

       })

       $scope.afterSelectConsultant=function($item, $model, $label){
           $scope.newAssignment.ConsultantId = $scope.selectedConsultant.ConsultantId;
       }

       //Clear Success Message
       $scope.clearMsg = function () {
           $scope.msg = "";
       }

       //Delete Assignment
       $scope.delete = function (assignmentId) {
           var res = $http.post("/api/Home/DeleteAssignment?assignmentId="+assignmentId);
           res.success(function (data, status, headers, config) {
               $scope.message = data;
               $scope.msg = "Assignment has been Deleted";
              
           });
           res.error(function (data, status, headers, config) {
               alert("failure message: " + JSON.stringify({ data: data }));
           });
       }

       //Selected Assignment To Delete
       $scope.selectAssignment = function (id) {
           $scope.selectedAssignmentId = id;
       }

       //updated Assignment
       $scope.updatedAssignment = function (value) {
          
           $scope.selectAssignmentToUpdate = {};
           startDate = new Date();
           startDate.setDate(new Date(value.StartDate).getDate() - 1);
           endDate = new Date();
           endDate.setDate(new Date(value.EndDate).getDate() - 1);
           $scope.selectAssignmentToUpdate = {
                   AssignmentId:value.AssignmentId,
                   AssignmentName:value.AssignmentName,
                   ClientName:value.ClientName,
                   Percentage: parseInt(value.Percentage),
                   StartDate: startDate,
                   EndDate: endDate,
                   Comment:value.Comment,
                   ConsultantId: value.ConsultantId

           }
           $scope.updatedSelectedConsultant = {};
           $scope.updatedSelectedConsultant.Name = value.ConsultantName;
       }

       //After Update Selected Consultant
       $scope.afterUpdateSelectConsultant = function ($item, $model, $label) {
           $scope.selectAssignmentToUpdate.ConsultantId = $scope.updatedSelectedConsultant.ConsultantId;
       }

       //Update Assignment
       $scope.update = function () {
           var res = $http.post("/api/Home/UpdateAssignment", $scope.selectAssignmentToUpdate);
           res.success(function (data, status, headers, config) {
               $scope.message = data;
               $scope.msg = "Assignment has been updated";

           });
           res.error(function (data, status, headers, config) {
               alert("failure message: " + JSON.stringify({ data: data }));
           });
       }

       //Add Consultant
       $scope.AddConsultant = function () {
           var newConsultant = {
               Name:$scope.addedConsultantName
           }
           var res = $http.post("/api/Home/CreateConsultant", newConsultant);
           res.success(function (data, status, headers, config) {
               $scope.message = data;

           });
           res.error(function (data, status, headers, config) {
               alert("failure message: " + JSON.stringify({ data: data }));
           });
       }

       //Select Consultant To Edit Or Delete
       $scope.selectConsultant = function (value) {
           $scope.selectedConsultant = value;
           console.log($scope.selectedConsultant);
       }

       //Update Consultant
       $scope.updateConsultant = function () {
           var updatedConsultant = {
               ConsultantId: $scope.id,
               Name: $scope.updatedConsultantName
           }
           console.log(updatedConsultant);
           var res = $http.post("/api/Home/UpdateConsultant", updatedConsultant);
           res.success(function (data, status, headers, config) {
               $scope.message = data;

           });
           res.error(function (data, status, headers, config) {
               alert("failure message: " + JSON.stringify({ data: data }));
           });
       }

       //Delete Consultant
       $scope.deleteConsultant = function () {
           consultantId = $routeParams.cons;
           var res = $http.post("/api/Home/DeleteConsultant?consultantId=" + consultantId);
           res.success(function (data, status, headers, config) {
               $scope.message = data;
               $scope.msg = "Assignment has been Deleted";

           });
           res.error(function (data, status, headers, config) {
               alert("failure message: " + JSON.stringify({ data: data }));
           });
       }

   });