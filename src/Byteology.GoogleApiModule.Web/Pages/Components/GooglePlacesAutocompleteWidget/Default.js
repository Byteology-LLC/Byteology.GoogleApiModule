function googlePlacesAutoCompleteWidgetInit() {

    var parent = $('.google-places-autocomplete-widget');

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
        selectionCssClass: ':all:',
        dropdownCssClass: ':all:',
        containerCssClass: ':all:',
        width: 'element',
        dropdownParent: parent,
        minimumInputLength: 4,
    });
};

$(document).ready(function () {   

    googlePlacesAutoCompleteWidgetInit();

    $(document.body).on('change', '.google-places-auto-complete', function () {
        var selection = $(this).select2('data')[0];
        $('#google-places-autocomplete-selection-placeid').val(selection.placeId);
    });

    $(document).on('select2:open', () => {
        document.querySelector('.select2-search__field').focus();
    });
});