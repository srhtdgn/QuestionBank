var FormInputMask = function () {

    var handleInputMasks = function () {

        $(".mask_number").inputmask({
            "mask": "9",
            "repeat": 2,
            "greedy": false
        }); // ~ mask "9" or mask "99" or ... mask "9999999999"
    }



    return {
        init: function () {
            handleInputMasks();
        }
    };
}();

if (App.isAngularJsApp() === false) {
    jQuery(document).ready(function () {
        FormInputMask.init(); // init metronic core componets
    });
}