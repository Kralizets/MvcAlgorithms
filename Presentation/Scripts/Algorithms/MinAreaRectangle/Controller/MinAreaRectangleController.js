var MinAreaRectangleController = /** @class */ (function () {
    function MinAreaRectangleController() {
    }
    MinAreaRectangleController.Init = function () {
        var self = this;
        var modalModalResult = $("#minAreaRectangle_modalResult");
        $('.closeModal').on('click', function () {
            modalModalResult.hide();
        });
        $("#minAreaRectangle_getResult").on('click', function () {
            self.GetResult();
            modalModalResult.show();
        });
    };
    MinAreaRectangleController.GetResult = function () {
        $.ajax({
            type: "POST",
            url: "/Algorithms/MinAreaRectangleResult",
            data: JSON.stringify(PointsController.GetPoints()),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#minAreaRectangleResult').text(result);
            }
        });
        return;
    };
    return MinAreaRectangleController;
}());
//# sourceMappingURL=MinAreaRectangleController.js.map