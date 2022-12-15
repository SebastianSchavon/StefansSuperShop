$(function(){
    
    var $subscribeForm = $("#subscribe-form");
    
    if($subscribeForm.length){
        $subscribeForm.validate({
            // define rules for html elements identified by their name 
            rules:{
                emailAddress:{
                    required:true
                }
            },
            // define error messages
            messages:{
                emailAddress:{
                    required: 'Email address required'
                }
            }
        })
    }
})