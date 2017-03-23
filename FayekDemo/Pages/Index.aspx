<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FayekDemo.Pages.Index" %>

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.5.5/angular.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.1/angular-route.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment.min.js"></script>
       <script src= "https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.17.1/locale/sv.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/angular-moment/0.9.0/angular-moment.min.js"></script>
    <script src="../Scripts/dirPagination.js"></script>
    <script src="../Scripts/ui-bootstrap.min.js"></script>
     <script src="../Scripts/app.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.6.1/css/font-awesome.min.css">
    <link href="../Content/Site.css" rel="stylesheet" />
    <meta charset="utf-8" />
</head>
<body  ng-app="App" ng-controller="Ctrl">
    <div class="container">
        <nav class="navbar navbar-default">
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li ><a href="#"> <select id="SrchAssignment" class="form-control" ng-model="srchAssignment"
             ng-options="template.AssignmentName for template  in assignmentView">
             <option value="">Filter By Assignments</option>
             </select></a></li>
        <li><a href="#"><select id="SrchConsultant" class="form-control" ng-model="srchConsultant"
             ng-options="template.ConsultantName for template  in assignmentView">
             <option value="">Filter By Consultants</option>
             </select></a></li>
      </ul>
      
      <ul class="nav navbar-nav navbar-right">
        <li><a href="#"><input type="text" class="form-control" placeholder="Search By Client" ng-model="term"></a></li>
        <li><a href="#/consultants/create" style="color:black"><span class="glyphicon glyphicon-plus"></span>Add Consultant</a></li>
        <li><a href="#/consultants" style="color:black"><span class="glyphicon glyphicon-list"></span>Show Consultants</a></li>

      </ul>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>

        <div ng-view></div>
        </div>
    

</body>

   
</html>
