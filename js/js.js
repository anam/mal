/*==============dropdownmenu==========*/
/*$(document).ready(function(){
	

//custom select box
//if( jQ('.selectOption').length > 0 ) jQ('.selectOption').selectbox();

$(".mainmenu li").hover(
function(){$(this).find('ul').stop(true, true).slideDown("fast");},
function (){$(this).find('ul').slideUp("fast");}
);

});*/

/*$(document).ready(function(){
	

//custom select box
//if( jQ('.selectOption').length > 0 ) jQ('.selectOption').selectbox();

$(".submenu li").hover(
function(){$(this).find('ul').stop(true, true).slideDown("fast");},
function (){$(this).find('ul').slideUp("fast");}
);

});*/
$(document).ready(function(){

	//Hide (Collapse) the toggle containers on load
	$(".toggle_container").hide(); 

	//Switch the "Open" and "Close" state per click then slide up/down (depending on open/close state)
	$(".trigger").click(function(){
		$(this).toggleClass("active").next().slideToggle("slow");
		return false; //Prevent the browser jump to the link anchor
	});

});


