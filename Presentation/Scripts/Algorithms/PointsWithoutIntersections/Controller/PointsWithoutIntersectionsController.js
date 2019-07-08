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
        this.DrawLineByPointsWithoutIntersections(points);
        modalResult.show();
        return;
    };
    PointsWithoutIntersectionsController.ShowResultFromPoints = function (points, modalResult, modalNotFound) {
        if (points.length == 0) {
            modalNotFound.show();
            return;
        }
        modalResult.show();
        this.DrawLineByPointsWithoutIntersections(points);
        return;
    };
    PointsWithoutIntersectionsController.DrawLineByPointsWithoutIntersections = function (points) {
        var addCanvas = $('.pointsWithoutIntersections_addCanvas');
        if (points.length == 1) {
            addCanvas.append('<div class=\"algorithms-min-area-rectangle-text-result\">' +
                '<span class=\"algorithms-horspool-text-result\">One points [' +
                points[0].X + '; ' + points[0].Y + ']</span></div>');
            return;
        }
        var canvas_html = document.createElement('canvas');
        canvas_html.id = "onePointsInCanvas";
        canvas_html.width = Math.ceil(this.GetWidthForCanvas(points));
        canvas_html.height = Math.ceil(this.GetHeightForCanvas(points));
        addCanvas.append(canvas_html);
        var canvas = canvas_html.getContext('2d');
        //canvas.beginPath();
        canvas.lineWidth = 5;
        canvas.strokeStyle = "red";
        for (var i = 0; i < (points.length - 1); i++) {
            canvas.moveTo(points[i].X, points[i].Y);
            canvas.lineTo(points[i + 1].X, points[i + 1].Y);
        }
        //canvas.stroke();
        return;
    };
    PointsWithoutIntersectionsController.GetWidthForCanvas = function (points) {
        var maxW = points[0].X;
        var deltaW = 100;
        points.forEach(function (point) {
            if (point.X > maxW) {
                maxW = point.X;
            }
        });
        return maxW + deltaW;
    };
    PointsWithoutIntersectionsController.GetHeightForCanvas = function (points) {
        var maxH = points[0].Y;
        var deltaH = 100;
        points.forEach(function (point) {
            if (point.Y > maxH) {
                maxH = point.Y;
            }
        });
        return maxH + deltaH;
    };
    return PointsWithoutIntersectionsController;
}());
//# sourceMappingURL=PointsWithoutIntersectionsController.js.map