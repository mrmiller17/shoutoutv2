//for use on manageent summary page
var shoutouts = [];
var currentmonth = new Date().getMonth() + 1;
var currentyear = new Date().getFullYear();
var monthly = []
var quarterly = []
var Q1 = 0
var Q2 = 0
var Q3 = 0
var Q4 = 0

$.ajax({
	type: "GET",
	url: "Shoutouts/GetShoutouts",
	success: function (data)
	{
		shoutouts = []
		monthly = []
		quarterly = []
		Q1 = 0
		Q2 = 0
		Q3 = 0
		Q4 = 0
		console.clear()
		if ($('.monthbox').selectedIndex !== 0) {
			currentmonth = parseInt($('.monthbox').val());
		}

		if ($('.yearbox').selectedIndex !== 0) {
			currentyear = parseInt($('.yearbox').val());
		}
		console.log(currentmonth)
		console.log(currentyear)
		$.each(data, function (i, v)
		{
			var dateObject = new Date(parseInt(this.DateTime.substr(6)));
			var month = (dateObject.getMonth() + 1);
			var year = (dateObject.getFullYear());

			if (currentmonth === month && currentyear === year) {
				monthly.push({
					recipient: v.RecipientId,
					level: v.LevelId
				});
			}

			switch (month) {
				case 1:
				case 2:
				case 3:
					if (currentyear === year) { Q1 += v.LevelId }
					break;
				case 4:
				case 5:
				case 6:
					if (currentyear === year) { Q2 += v.LevelId; }
					break;
				case 7:
				case 8:
				case 9:
					if (currentyear === year) { Q3 += v.LevelId }
					break;
				case 10:
				case 11:
				case 12:
					if (currentyear === year) { Q4 += v.LevelId }
					break;
			}

		})

		var totalshout = Q1 + Q2 + Q3 + Q4
		$('.monthinsert').empty();
		$('.quarterinsert').empty();
		$('.quarterinsert').append('Q1: ' + Q1 + ', Q2: ' + Q2 + ', Q3: ' + Q3 + ', Q4: ' + Q4 + ', Total: ' + totalshout)
		$('.monthinsert').append(monthly.length);

		$.each(data, function (i, v)
		{
			var pointtot = 0;
			var dateObject = new Date(parseInt(this.DateTime.substr(6)));
			var month = (dateObject.getMonth() + 1);
			var year = (dateObject.getFullYear());
			if (currentmonth === month && currentyear === year) { pointtot += v.LevelId }
			console.log(month)
			console.log(year)
			Q1 = 0
			Q2 = 0
			Q3 = 0
			Q4 = 0
			switch (month) {
				case 1:
				case 2:
				case 3:
					if (currentyear === year) { Q1 += v.LevelId }
					break;
				case 4:
				case 5:
				case 6:
					if (currentyear === year) { Q2 += v.LevelId; }
					break;
				case 7:
				case 8:
				case 9:
					if (currentyear === year) { Q3 += v.LevelId }
					break;
				case 10:
				case 11:
				case 12:
					if (currentyear === year) { Q4 += v.LevelId }
					break;
			}
			shoutouts.push({
				recipient: v.RecipientId,
				level: pointtot,
				q1points: Q1,
				q2points: Q2,
				q3points: Q3,
				q4points: Q4
			});
		})

		var res = alasql('SELECT recipient, SUM(level) AS points, SUM(q1points) as q1points, SUM(q2points) as q2points, SUM(q3points) as q3points, SUM(q4points) as q4points FROM ? GROUP BY recipient', [shoutouts]);

		var users = [];
		$.ajax({
			type: "GET",
			url: "Account/GetUsers",
			success: function (data)
			{
				var final = []


				$(data).each(function (e, v)
				{
					var id = v.Id
					var sfirstname = v.FirstName;
					var slastname = v.LastName;
					$(res).each(function (e)
					{
						if (this.recipient === id) {
							final.push({
								firstName: sfirstname,
								lastName: slastname,
								points: this.points,
								q1points: this.q1points,
								q2points: this.q2points,
								q3points: this.q3points,
								q4points: this.q4points,
							})
						}
					})
				})
				$('#tb').empty();
				$(final).each(function ()
				{
					$('#tb').append('<tr>')
					$('#tb').append('<td>' + this.firstName + '</td>');
					$('#tb').append('<td>' + this.lastName + '</td>');
					$('#tb').append('<td>' + this.points + '</td>');
					$('#tb').append('<td>' + this.q1points + '</td>');
					$('#tb').append('<td>' + this.q2points + '</td>');
					$('#tb').append('<td>' + this.q3points + '</td>');
					$('#tb').append('<td>' + this.q4points + '</td>');
					$('#tb').append('</tr>')
				})

			},

		})
	}
})

$('.monthbox').change(function (){
	reload()
})
$('.yearbox').change(function ()
{
	reload()
})


function reload()
{
	$.ajax({
		type: "GET",
		url: "Shoutouts/GetShoutouts",
		success: function (data)
		{
			shoutouts = []
			monthly = []
			quarterly = []
			Q1 = 0
			Q2 = 0
			Q3 = 0
			Q4 = 0
			console.clear()
			if ($('.monthbox').selectedIndex !== 0) {
				currentmonth = parseInt($('.monthbox').val());
			}

			if ($('.yearbox').selectedIndex !== 0) {
				currentyear = parseInt($('.yearbox').val());
			}
			console.log(currentmonth)
			console.log(currentyear)
			$.each(data, function (i, v)
			{
				var dateObject = new Date(parseInt(this.DateTime.substr(6)));
				var month = (dateObject.getMonth() + 1);
				var year = (dateObject.getFullYear());
				
				if (currentmonth === month && currentyear === year) {
					monthly.push({
						recipient: v.RecipientId,
						level: v.LevelId
					});
				}
				console.log(Q2)
				switch (month) {
					case 1:
					case 2:
					case 3:
						if (currentyear === year) { Q1 += 1 }
						break;
					case 4:
					case 5:
					case 6:
						if (currentyear === year) { Q2 += 1 }
						break;
					case 7:
					case 8:
					case 9:
						if (currentyear === year) { Q3 += 1 }
						break;
					case 10:
					case 11:
					case 12:
						if (currentyear === year) { Q4 += 1 }
						break;
				}

			})

			var totalshout = Q1 + Q2 + Q3 + Q4
			$('.monthinsert').empty();
			$('.quarterinsert').empty();
			$('.quarterinsert').append('Q1: ' + Q1 + ', Q2: ' + Q2 + ', Q3: ' + Q3 + ', Q4: ' + Q4 + ', Total: ' + totalshout)
			$('.monthinsert').append(monthly.length);

			$.each(data, function (i, v)
			{
				var pointtot = 0;
				var dateObject = new Date(parseInt(this.DateTime.substr(6)));
				var month = (dateObject.getMonth() + 1);
				var year = (dateObject.getFullYear());
				if (currentmonth === month && currentyear === year) { pointtot += v.LevelId }
				console.log(month)
				console.log(year)
				Q1 = 0
				Q2 = 0
				Q3 = 0
				Q4 = 0
				switch (month) {
					case 1:
					case 2:
					case 3:
						if (currentyear === year) { Q1 += v.LevelId }
						break;
					case 4:
					case 5:
					case 6:
						if (currentyear === year) { Q2 += v.LevelId;}
						break;
					case 7:
					case 8:
					case 9:
						if (currentyear === year) { Q3 += v.LevelId }
						break;
					case 10:
					case 11:
					case 12:
						if (currentyear === year) { Q4 += v.LevelId }
						break;
				}
				shoutouts.push({
					recipient: v.RecipientId,
					level: pointtot,
					q1points: Q1,
					q2points: Q2,
					q3points: Q3,
					q4points: Q4
				});
			})

			var res = alasql('SELECT recipient, SUM(level) AS points, SUM(q1points) as q1points, SUM(q2points) as q2points, SUM(q3points) as q3points, SUM(q4points) as q4points FROM ? GROUP BY recipient', [shoutouts]);

			var users = [];
			$.ajax({
				type: "GET",
				url: "Account/GetUsers",
				success: function (data)
				{
					var final = []


					$(data).each(function (e, v)
					{
						var id = v.Id
						var sfirstname = v.FirstName;
						var slastname = v.LastName;
						$(res).each(function (e)
						{
							if (this.recipient === id) {
								final.push({
									firstName: sfirstname,
									lastName: slastname,
									points: this.points,
									q1points: this.q1points,
									q2points: this.q2points,
									q3points: this.q3points,
									q4points: this.q4points,
								})
							}
						})
					})
					$('#tb').empty();
					$(final).each(function ()
					{
						$('#tb').append('<tr>')
						$('#tb').append('<td>' + this.firstName + '</td>');
						$('#tb').append('<td>' + this.lastName + '</td>');
						$('#tb').append('<td>' + this.points + '</td>');
						$('#tb').append('<td>' + this.q1points + '</td>');
						$('#tb').append('<td>' + this.q2points + '</td>');
						$('#tb').append('<td>' + this.q3points + '</td>');
						$('#tb').append('<td>' + this.q4points + '</td>');
						$('#tb').append('</tr>')
					})

				},

			})
		}
	})
}





