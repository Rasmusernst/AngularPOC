//create angularjs controller
var app = angular.module('app', []);//set and get the angular module
app.controller('BooksController', ['$scope', '$http', BooksController]);

//angularjs controller method
function BooksController($scope, $http) {

    //declare variable for maintain ajax load and entry or edit mode
    $scope.loading = true;
    $scope.addMode = false;

    //Get all Books
    $http.get('/api/Books/').success(function (data) {
        $scope.books = data;
        $scope.loading = false;
    });


    //Create Book
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Books/', this.newbook).success(function (data) {
            alert("Added Successfully!");
            $scope.customers.push(data);
            $scope.loading = false;
        });
    };

    //Edit Book
    $scope.save = function () {
        $scope.loading = true;
        var book = this.book;
        $http.put('/api/Books/' + book.Id, book).success(function (data) {
            alert("Book wih ID: "+book.Id+ " Saved Successfully!!");
            $scope.loading = false;
        })
    };

    //Delete Book
    $scope.deleteBook = function () {
        $scope.loading = true;
        var Id = this.book.Id;
        $http.delete('/api/Books/' + Id).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.books, function (i) {
                if ($scope.books[i].Id === Id) {
                    $scope.books.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        })
    };

}