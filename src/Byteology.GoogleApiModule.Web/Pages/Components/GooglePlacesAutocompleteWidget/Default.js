$(document).ready(function () {
    $('.google-places-auto-complete').select2({
        ajax: {
            url: '/api/google-apis/google-places/auto-complete',
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
                // Transforms the top-level key of the response object from 'items' to 'results'
                return {
                    results: $.map(data.predictions, function (obj) {
                        obj.id = obj.id || obj.description; // replace pk with your identifier
                        obj.text = obj.text || obj.description;

                        return obj;
                    })
                };
            }
        },
        placeholder: 'Search for an Address',
        minimumInputLength: 4,
    });
});