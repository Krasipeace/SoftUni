// console.log( 'hi, the file loads' );

jQuery(document).ready(function($) {
    $('.like-button').on('click', function(e){
        e.preventDefault();
        // console.log( 'clicked' ); //  test

        let job_id = jQuery(this).attr('id') 

        // AJAX Magic
        jQuery.ajax({
            type: 'post',
            dataType: 'json',
            url: my_ajax_object.ajax_url,
            data: {
                action:'softuni_job_like', 
                job_id: job_id 
            },
            success: function(msg){
                console.log(msg);
            }
        });
    });
});