var MinAreaRectangleController = /** @class */ (function () {
    function MinAreaRectangleController() {
    }
    MinAreaRectangleController.Init = function () {
        var self = this;
        var modalInputPoint = $('#minAreaRectangle_modalAddPoint');
        var modalIsSuccessfullAddPoint = $('#minAreaRectangle_modalIsSuccessfullyAddPoint');
        var modalShowAllPoints = $("#minAreaRectangle_modalShowAllPoints");
        var modalModalResult = $("#minAreaRectangle_modalResult");
        $('#minAreaRectangle_addPoint').on('click', function () {
            modalInputPoint.show();
        });
        $('#minAreaRectangle_addPointInList').on('click', function () {
            self.DataCorrectness();
            modalIsSuccessfullAddPoint.show();
        });
        $('#minAreaRectangle_showAllPoints').on('click', function () {
            self.ShowAllPoints();
            modalShowAllPoints.show();
        });
        $('.minAreaRectangle_closeModal').on('click', function () {
            modalInputPoint.hide();
            modalIsSuccessfullAddPoint.hide();
            modalShowAllPoints.hide();
            modalModalResult.hide();
        });
        $("#minAreaRectangle_getResult").on('click', function () {
            self.GetResult();
            modalModalResult.show();
        });
    };
    MinAreaRectangleController.DataCorrectness = function () {
        var self = this;
        var regex = /^(-{0,1}\d+)(\.)(\d+)$/;
        var isSuccessfully = $('#minAreaRectangle_isSuccessfully');
        var getPointX = $('#getPointX');
        var getPointY = $('#getPointY');
        var pointX = getPointX.val();
        var pointY = getPointY.val();
        getPointX.val("");
        getPointY.val("");
        if (pointX != "" && pointY != "" && regex.test(pointX) && regex.test(pointY)) {
            var point = new Point(parseFloat(pointX), parseFloat(pointY));
            self.points.push(point);
            isSuccessfully.text("The point with coordinates (" + pointX + ", " + pointY + ") successfully added to the list!");
            return;
        }
        isSuccessfully.text("The point with coordinates (" + pointX + ", " + pointY + ") cannot be added to the list!");
        return;
    };
    MinAreaRectangleController.ShowAllPoints = function () {
        var self = this;
        var showAllPointsBody = $("#showAllPointsBody");
        $(".internal-show-all-points-body").remove();
        if (self.points.length == 0) {
            showAllPointsBody.append('<div class=\"internal-show-all-points-body\">\r\n<span class=\"input-text\">No point has been added to the list!</span>\r\n</div>');
            return;
        }
        var listShowAllPoints = '<div class=\"internal-show-all-points-body\">\r\n<ol class=\"rounded\">\r\n';
        self.points.forEach(function (point) {
            listShowAllPoints = listShowAllPoints + '<li><a>Point: [x = ' + point.X + '; y = ' + point.Y + ']</a></li>\r\n';
        });
        listShowAllPoints = listShowAllPoints + '</ol>\r\n</div>';
        showAllPointsBody.append(listShowAllPoints);
        return;
    };
    MinAreaRectangleController.GetResult = function () {
        var self = this;
        $.ajax({
            type: "POST",
            url: "/Algorithms/MinAreaRectangleResult",
            data: JSON.stringify(self.points),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#minAreaRectangleResult').text(result);
            }
        });
        return;
    };
    MinAreaRectangleController.points = new Array();
    return MinAreaRectangleController;
}());
//# sourceMappingURL=MinAreaRectangleController.js.map