$(document).ready(function() {
	 if ($(window).width() < 568) {
      
      	$('.accordionButton').click(function() {

      	 	$('.accordionContent').slideUp('normal');
         
      		if($(this).find('.accordionContent').is(':hidden') == true) {
      			
      			$(this).find('.accordionContent').slideDown('normal');
      		 } 
      		  
      	 });
      	  
      	$('.accordionContent').hide();
    };
});