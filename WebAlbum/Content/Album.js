var Album = function () {

    var ListaAlbum = function () {

        $.ajax({
            url: '/Album/ListaAlbum',
            data: "",
            type: 'GET',
            contentType: "application/json",
            success: function (data) {
                $('#lstAlbum').find('option').remove();
                $("#lstAlbum").append("<option value='0'>Seleccione</option >");

                $.each(data, function (i, item) {
                    $("#lstAlbum").append('<option data-userId=' + item.userId + ' value=' + item.id + '>' + item.title + '</option > ');
                });


            }
        });

    }


  
    var InitControl = function () {
        $("#btnVisualizar").click(function () {

            var request = {
                id: $("#lstAlbum option:selected").val(),
                userId: 0,
                title: ""
            }


            $.ajax({
                url: '/Album/AlbumPhotos',
                data: JSON.stringify(request),
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {


                    var $table = $('<table class="table table-striped table-bordered table-hover"/>');
                    $table.append('<thead><tr><th>id</th><th>Titulo</th><th>url</th><th>thumbnailUrl</th></tr></thead>');
                    var $tbody = $('<tbody/>');
                    $.each(data, function (i, val) {
                        var $row = $('<tr/>');
                        $row.append($('<td/>').html(val.id));
                        $row.append($('<td/>').html(val.title));
                        $row.append($('<td/>').html(val.url));
                        $row.append($('<td/>').html(val.thumbnailUrl));
                        var $Comment = $('<a id="lnkComentario" href="#">Ver Comentario</a>');
                        $Comment.click(function (e) {
                            e.preventDefault();
                        });
                        $row.append($('<td/>').html($Comment));
                        $tbody.append($row);
                    });
                
                    $table.append($tbody);
                    $('#PhotosTable').html($table);

                    $('#PhotosTable tbody').on('click', 'a[id="lnkComentario"]', function () {


                        var request = {
                            id: $(this).closest('tr').find('td:nth-child(1)').html()
                        }

                        $.ajax({
                            url: '/Album/ComentarioPhoto',
                            data: JSON.stringify(request),
                            type: 'POST',
                            contentType: "application/json",
                            success: function (data) {


                                alert(data[0].body);
                                $(".modal-body").append("");
                                //$('#myModal').modal('show');


                                //$(".modal-body").append(data);

                            }
                        });
                    });


                }
            });

        });
    }


    return {
        init: function () {
            ListaAlbum();
            InitControl()
        }
    }

}();


$(document).ready(function () {
    Album.init();
});