var PointsController = /** @class */ (function () {
    function PointsController() {
    }
    PointsController.Init = function () {
        var self = this;
        var modalInputPoint = $('#modalAddPoint');
        var modalIsSuccessfullAddPoint = $('#modalIsSuccessfullyAddPoint');
        var modalShowAllPoints = $('#modalShowAllPoints');
        $('#addPoint').on('click', function () {
            modalInputPoint.show();
        });
        $('#addPointInList').on('click', function () {
            self.DataCorrectness();
            modalIsSuccessfullAddPoint.show();
        });
        $('#showAllPoints').on('click', function () {
            self.ShowAllPoints();
            modalShowAllPoints.show();
        });
        $('.closeModal').on('click', function () {
            modalInputPoint.hide();
            modalIsSuccessfullAddPoint.hide();
            modalShowAllPoints.hide();
        });
    };
    PointsController.GetPoints = function () {
        return this.points;
    };
    PointsController.DataCorrectness = function () {
        var self = this;
        var regex = /^(-{0,1}\d+)(\.)(\d+)$/;
        var isSuccessfully = $('#isSuccessfully');
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
    PointsController.ShowAllPoints = function () {
        var self = this;
        var showAllPointsBody = $('#showAllPointsBody');
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
    PointsController.points = new Array();
    return PointsController;
}());
//# sourceMappingURL=PointsController.js.map