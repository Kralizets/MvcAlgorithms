var MinAreaRectangleController = /** @class */ (function () {
    function MinAreaRectangleController() {
    }
    MinAreaRectangleController.Init = function () {
        var self = this;
        var modalInputPoint = $('#minAreaRectangle_modalAddPoint');
        var modalIsSuccessfullAddPoint = $('#minAreaRectangle_modalIsSuccessfullyAddPoint');
        $('#minAreaRectangle_addPoint').on('click', function () {
            modalInputPoint.show();
        });
        $('#minAreaRectangle_addPointInList').on('click', function () {
            self.DataCorrectness();
            modalIsSuccessfullAddPoint.show();
        });
        $('.minAreaRectangle_closeModal').on('click', function () {
            modalInputPoint.hide();
            modalIsSuccessfullAddPoint.hide();
        });
    };
    MinAreaRectangleController.DataCorrectness = function () {
        var self = this;
        var regex = new RegExp("(-{0,1}\d+)[.](\d+)");
        var pointX = $('#getPointX').val();
        var pointY = $('#getPointY').val();
        $('#getPointX').val("");
        $('#getPointY').val("");
        //debugger;
        //if (pointX != "" && pointY != "" && regex.test(pointX) && regex.test(pointY)) {
        //    var point = new Point(pointX, pointY);
        //    MinAreaRectangleController.points.push(point);
        //    $('#minAreaRectangle_isSuccessfully').text("The point with coordinates (" + pointX + ", " + pointY + ") successfully added to the list!");
        //    return;
        //}
        $('#minAreaRectangle_isSuccessfully').text("The point with coordinates (" + pointX + ", " + pointY + ") cannot be added to the list!");
        var point = new Point(pointX, pointY);
        debugger;
        self.points.push(point);
        return;
    };
    MinAreaRectangleController.points = new Array();
    return MinAreaRectangleController;
}());
//# sourceMappingURL=MinAreaRectangleController.js.map