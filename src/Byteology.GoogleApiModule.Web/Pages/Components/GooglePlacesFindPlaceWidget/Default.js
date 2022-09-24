$(document).ready(function () {
    $('.google-places-find-place').select2({
        ajax: {
            url: '/api/google-apis/google-places/find',
            type: "post",
            contentType: "application/json",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return JSON.stringify({
                    "input": params.term
                });
            },
            processResults: function (data) {
                return {
                    results: $.map(data.candidates, function (obj) {
                        obj.id = obj.id || obj.formattedAddress;
                        obj.text = obj.text || obj.formattedAddress;

                        return obj;
                    })
                };
            }
        },
        placeholder: 'Search for an Place',
        minimumInputLength: 4,
        templateResult: formatPlace,
        templateSelection: formatPlaceSelection
    });


    function formatPlace(place) {
        if (place.loading) {
            return place.text;
        }

        var $container = $(
            "<div class='col'>"+
            "<div class='d-flex flex-start align-items-center' > "+
            "<img class='img-thumbnail shadow-1-strong me-3' src='https://via.placeholder.com/65' alt='image' width='65'	height='65' />" +
            "<div class='flex-grow-1 flex-shrink-1'>" +
            "<div>" +
            "<div class='d-flex justify-content-between align-items-center'>" +
            "<p class='mb-1 fw-bold google-places-find-place_name'></p>" +
            "</div>" +
            "<p class='small mb-0 google-places-find-place_address'></p>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "</div> "
        );


        if (place.photos.length > 0)
            $container.find("img").attr("src", "/api/google-apis/google-places/photo/" + place.photos[0].photoReference + "?maxHeight=65&maxWidth=65")
        else
            $container.find("img").remove();

        $container.find(".google-places-find-place_name").text(place.name);
        $container.find(".google-places-find-place_address").text(place.formattedAddress);
        

        return $container;
    }

    function formatPlaceSelection(place) {
        return place.formattedAddress || place.text;
    }

    $('.google-places-find-place').on('change', function () {
        var selection = $(this).select2('data')[0];
        $('#google-places-find-place-selection-placeid').val(selection.placeId);
    });
});