$(document).ready(function () {
    $(document).on("click", ".page-link-ajax", function (e) {
        e.preventDefault(); // Evita la recarga de la página

        var page = $(this).data("page");
        var nombreCiudad = $("#nombreCiudad").val(); // Recuperamos la ciudad desde el input oculto

        $.ajax({
            url: "/Home/Imagen",
            type: "GET",
            data: { nombreCiudad: nombreCiudad, page: page },
            success: function (data) {
                if (data.success === false) {
                    alert(data.message); // Muestra el mensaje de error del servidor
                } else {
                    $("#imagenesContainer").html(data); // Actualiza solo la PartialView
                }
            },
            error: function (xhr, status, error) {
                alert("Error al cargar las imágenes: " + error);
            }
        });
    });
});
