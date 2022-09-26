(function () {
    

    var _createModal = new abp.ModalManager(
        abp.appPath + 'GoogleApiModule/ModalTest/CreateModal'
    );

    $(document.body).on('click', '#test-modal-button', function (e) {       
        _createModal.open();        
    });

    //add this if you are using the ModalManager to create a Modal to initialize the widgets
    _createModal.onOpen(function () {
        googlePlacesAutoCompleteWidgetInit();
        googlePlacesFindPlaceWidgetInit();
    });

})();