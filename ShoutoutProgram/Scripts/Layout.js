// logout time set to 10 min
var timout = 600000; 

//starts the timer on page load
window.onload = function ()
{
	timeoutTimer = setTimeout("IdleTimeout()", timout);
	refresh();//used with alexa
	marq();
	Marquee3k.init();
	Marquee3k.refreshAll();
}


var timeoutTimer;

// Start timers.
function StartTimers()
{
	timeoutTimer = setTimeout("IdleTimeout()", timout);
}

// Reset timers.
document.addEventListener('click', reset)
document.addEventListener('mousemove', reset)
document.addEventListener('keypress', reset)
function reset()
{
	clearTimeout(timeoutTimer);
	StartTimers();
}

// Logout the user.
function IdleTimeout()
{
	try {
		document.getElementById('logoutForm').submit();
	}
	catch
	{

	}
}


//used to store db query for ticker
var my_data = [];


var marq = function ()
{
	$.ajax({
		type: "GET",
		url: "/home/GetEvents",
		success: function (data)
		{
			$.each(data, function (i, v)
			{
				my_data.push({
					eventID: v.EventId,
					title: v.Subject,
					description: v.Description,
					start: moment(v.Start),
					end: v.End != null ? moment(v.End) : null,
					color: v.ThemeColor,
					allDay: v.IsFullDay,
					isTicker: v.IsTicker
				});
			})

			my_data.forEach(function (e)
			{
				if (e.isTicker === true) {
					$('.appMe').empty();
				}
			})
				
			
			//appends stored data to event ticker before running
			my_data.forEach(function (datahold)
			{
				if (datahold.isTicker === true) {
					$('.appMe').append('****' + datahold.title + ' : ' + datahold.description + '****')
				}
			});
		},
		error: function (error)
		{
			alert('failed');
		}
	})
}






//var users = []
//$.ajax({
//	type: "GET",
//	url: "Account/GetUsers",
//	success: function (data)
//	{
//		$.each(data, function (i, v)
//		{
//			users.push({
//				userFName: v.FirstName,
//				userLName: v.LastName
//			});
//		}) 
//		console.log(users)
//	},
//})

//changes webpage to alexa db command
function navigateWebpage(address)
{
	
	var image_path = address;
	
	window.location.href = address;

}
var pleasework = null;

//keeps a conection with the alexa db
function refresh()
{
	
	var xhttp = new XMLHttpRequest();
	xhttp.open("GET", "https://9ftlgnqwz0.execute-api.us-east-1.amazonaws.com/prod", true);
	xhttp.send();
	xhttp.addEventListener('readystatechange', processRequest, false);

	function processRequest(e)
	{
		if (xhttp.readyState == 4 && xhttp.status == 200) {
			
			var response = JSON.parse(xhttp.responseText);
			
			var webString = response.website;

			if (pleasework === null) {
				pleasework = webString;
			}
			if (pleasework !== webString) {
				navigateWebpage(webString);
			}
		}
	}
	setTimeout(refresh, 1000);
}

//function pollServer()
//{
//	if (isActive) {
//window.setTimeout(function ()
//{
//	$.ajax({
//		url: "https://9ftlgnqwz0.execute-api.us-east-1.amazonaws.com/prod",
//		type: "POST",
//		success: function (result)
//		{
//			result.addEventListener('readystatechange', )
//			pollServer();
//		},
//		error: function ()
//		{
//			//ERROR HANDLING
//			pollServer();
//		}
//	});
//}, 2500);




//$(document).ready(function ()
//{

//	$('.tickaway').SimpleMarquee({

//		// controls the speed at which the marquee moves
//		duration: 30000,

//		// right margin between consecutive marquees
//		padding: -1,

//		// class of the actual div or span that will be used to create the marquee - 
//		// multiple marquee items may be created using this item's content. 
//		// This item will be removed from the dom
//		marquee_class: '.marquee',

//		// the container div in which the marquee content will animate. 
//		container_class: '.tickaway',

//		// a sibling item to the marqueed item  that affects - 
//		// the end point position and available space inside the container. 
//		sibling_class: '.marquee-sibling',

//		// Boolean to indicate whether pause on hover should is required. 
//		hover: true

//	});

//});



