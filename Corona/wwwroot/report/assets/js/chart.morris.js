$(function(){
	
	/* Morris Area Chart */
	
	window.mA = Morris.Area({
	    element: 'nkwakxArea',
	    data: [
	        { y: '2015', a: 60},
	        { y: '2016', a: 100},
	        { y: '2017', a: 240},
	        { y: '2018', a: 120},
	        { y: '2019', a: 80},
	        { y: '2020', a: 300},
	        { y: '2021', a: 50},
	    ],
	    xkey: 'y',
	    ykeys: ['a'],
	    labels: ['Walkins'],
	    lineColors: ['#1b5a90'],
	    lineWidth: 2,
		
     	fillOpacity: 0.5,
	    gridTextSize: 10,
	    hideHover: 'auto',
	    resize: true,
		redraw: true
	});
	
	/* Morris Line Chart */
	
	window.mL = Morris.Line({
	    element: 'nkwakxLine',
	    data: [
	        { y: '2017', a: 100, b: 30, c:70},
	        { y: '2018', a: 20,  b: 60, c:40},
	        { y: '2019', a: 90,  b: 120, c:30},
	        { y: '2020', a: 50,  b: 80, c:90},
	        { y: '2021', a: 120,  b: 150, c:160},
	    ],
	    xkey: 'y',
	    ykeys: ['a', 'b'],
	    labels: ['Doctors', 'Patients', 'Nurse'],
	    lineColors: ['#1b5a90','#ff9d00', '#1b9051'],
	    lineWidth: 1,
	    gridTextSize: 10,
	    hideHover: 'auto',
	    resize: true,
		redraw: true
	});
	$(window).on("resize", function(){
		mA.redraw();
		mL.redraw();
	});

});