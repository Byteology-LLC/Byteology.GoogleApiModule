(function ($) {
    $(function () {

        $("#GoogleApiModuleSettingsForm").on('submit', function (event) {
            event.preventDefault();

            if (!$(this).valid()) {
                return;
            }

            var form = $(this).serializeFormToObject();
            byteology.googleApiModule.settings.googleApiModuleSettings.update(form).then(function (result) {
                $(document).trigger("AbpSettingSaved");
            });
        });
    });

})(jQuery);

