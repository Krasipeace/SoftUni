jQuery(document).ready(function($) {
    $('.like-button').on('click', function(e){
        e.preventDefault();

        let property_id = jQuery(this).attr('id') 

        jQuery.ajax({
            type: 'post',
            dataType: 'json',
            url: my_ajax_object.ajax_url,
            data: {
                action:'softuni_property_like', 
                property_id: property_id 
            },
            success: function(msg){
                console.log(msg);
            }
        });
    });
});