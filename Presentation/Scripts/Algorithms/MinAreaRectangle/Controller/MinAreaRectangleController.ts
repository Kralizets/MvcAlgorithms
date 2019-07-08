class MinAreaRectangleController {
    public static Init() {
        var self = this;

        var modalModalResult = $("#minAreaRectangle_modalResult");

        $('.closeModal').on('click', function () {
            modalModalResult.hide();
        });

        $("#minAreaRectangle_getResult").on('click', function () {
            self.GetResult();
            modalModalResult.show();
        });
    }

    private static GetResult() {
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
    }
}