var PointsWithoutIntersectionsController = /** @class */ (function () {
    function PointsWithoutIntersectionsController() {
    }
    PointsWithoutIntersectionsController.Init = function () {
        var self = this;
        var modalModalResultFromFiles = $('#pointsWithoutIntersections_modalResultFromFiles');
        var modalModalResultFromPoints = $('#pointsWithoutIntersections_modalResultFromPoints');
        var modalModalResultNotFound = $('#pointsWithoutIntersections_modalResultNotFound');
        $('.closeModal').on('click', function () {
            modalModalResultFromFiles.hide();
            modalModalResultFromPoints.hide();
            modalModalResultNotFound.hide();
        });
        $('#pointsWithoutIntersections_getResultFromFiles').on('click', function () {
            self.GetResultFromFiles(modalModalResultFromFiles, modalModalResultNotFound);
        });
        $('#pointsWithoutIntersections_getResultFromPoints').on('click', function () {
            self.GetResultFromPoints(modalModalResultFromPoints, modalModalResultNotFound);
        });
    };
    PointsWithoutIntersectionsController.GetResultFromFiles = function (modalResult, modalNotFound) {
        var self = this;
        $.ajax({
            type: "POST",
            url: "/Algorithms/PointsWithoutIntersectionsResultFromFiles",
            success: function (result) {
                self.ShowResultFromFiles(result, modalResult, modalNotFound);
            }
        });
        return;
    };
    PointsWithoutIntersectionsController.GetResultFromPoints = function (modalResult, modalNotFound) {
        var self = this;
        $.ajax({
            type: "POST",
            url: "/Algorithms/PointsWithoutIntersectionsResultFromPoints",
            data: JSON.stringify(PointsController.GetPoints()),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                self.ShowResultFromPoints(result, modalResult, modalNotFound);
            }
        });
        return;
    };
    PointsWithoutIntersectionsController.ShowResultFromFiles = function (points, modalResult, modalNotFound) {
        if (points.length == 0) {
            modalNotFound.show();
            return;
        }
        var self = this;
        self.ShowModalResultFromFiles(points);
        modalResult.show();
        return;
    };
    PointsWithoutIntersectionsController.ShowResultFromPoints = function (points, modalResult, modalNotFound) {
        if (points.length == 0) {
            modalNotFound.show();
            return;
        }
        var self = this;
        self.ShowModalResultFromPoints(points);
        modalResult.show();
        return;
    };
    //need refactoring
    PointsWithoutIntersectionsController.ShowModalResultFromFiles = function (points) {
        var showAllPointsBody = $('#showAllPointsBodyWithoutIntersectionsFromFiles');
        $(".internal-show-all-points-body").remove();
        var listShowAllPoints = '<div class=\"internal-show-all-points-body\">\r\n<ol class=\"rounded\">\r\n';
        points.forEach(function (point) {
            listShowAllPoints = listShowAllPoints + '<li><a>Point: [x = ' + point.X + '; y = ' + point.Y + ']</a></li>\r\n';
        });
        listShowAllPoints = listShowAllPoints + '</ol>\r\n</div>';
        showAllPointsBody.append(listShowAllPoints);
        return;
    };
    PointsWithoutIntersectionsController.ShowModalResultFromPoints = function (points) {
        var showAllPointsBody = $('#showAllPointsBodyWithoutIntersectionsFromPoints');
        $(".internal-show-all-points-body").remove();
        var listShowAllPoints = '<div class=\"internal-show-all-points-body\">\r\n<ol class=\"rounded\">\r\n';
        points.forEach(function (point) {
            listShowAllPoints = listShowAllPoints + '<li><a>Point: [x = ' + point.X + '; y = ' + point.Y + ']</a></li>\r\n';
        });
        listShowAllPoints = listShowAllPoints + '</ol>\r\n</div>';
        showAllPointsBody.append(listShowAllPoints);
        return;
    };
    return PointsWithoutIntersectionsController;
}());
//# sourceMappingURL=PointsWithoutIntersectionsController.js.map