'use strict';$(document).ready(function(){$('#ex1').slider({formatter:function(value){return'Current value: '+ value;}});$("#ex2").slider({});//#ex3
var RGBChange=function(){$('#RGB').css('background','rgb('+ r.getValue()+','+ g.getValue()+','+ b.getValue()+')')};var r=$('#R').slider().on('slide',RGBChange).data('slider');var g=$('#G').slider().on('slide',RGBChange).data('slider');var b=$('#B').slider().on('slide',RGBChange).data('slider');//#ex4
$("#ex4").slider({reversed:true});//#ex6
$("#ex6").slider();$("#ex6").on("slide",function(slideEvt){$("#ex6SliderVal").text(slideEvt.value);});//#8
var slider=new Slider("#ex8",{tooltip:'always'});//#9
var slider=new Slider("#ex9",{precision:2,value:8.115});//#10
var slider=new Slider("#ex10",{});//#11
var slider=new Slider("#ex11",{step:20000,min:0,max:200000,tooltip:'always'});//#12
$("#ex12a").slider({id:"slider12a",min:0,max:10,value:5});$("#ex12b").slider({id:"slider12b",min:0,max:10,range:true,value:[3,7]});$("#ex12c").slider({id:"slider12c",min:0,max:10,range:true,value:[3,7]});//#13
$("#ex13").slider({ticks:[0,100,200,300,400],ticks_labels:['$0','$100','$200','$300','$400'],ticks_snap_bounds:30});//#14
$("#ex14").slider({ticks:[0,100,200,300,400],ticks_positions:[0,30,60,70,90,100],ticks_labels:['$0','$100','$200','$300','$400'],ticks_snap_bounds:30});$("#ex15").slider({min:1000,max:10000000,scale:'logarithmic',step:10});//#16
$("#ex16a").slider({min:0,max:10,value:0,focus:true});$("#ex16b").slider({min:0,max:10,value:[0,10],focus:true});$("#ex17a").slider({min:0,max:10,value:0,tooltip_position:'bottom'});$("#ex17b").slider({min:0,max:10,value:0,orientation:'vertical',tooltip_position:'left'});$("#ex18a").slider({min:0,max:10,value:5,labelledby:'ex18-label-1'});$("#ex18b").slider({min:0,max:10,value:[3,6],labelledby:['ex18-label-2a','ex18-label-2b']});//#ex19 no script
//#ex20
$('#ex20a').on('click',function(e){$('#ex20a').parent().find(' >.well').toggle().find('input').slider('relayout');e.preventDefault();});//#21 no script
//#22
$('#ex22').slider({id:'slider22',min:0,max:20,step:1,value:14,rangeHighlights:[{"start":2,"end":5},{"start":7,"end":8},{"start":17,"end":19},{"start":17,"end":24},{"start":-3,"end":19}]});//#23
$("#ex23").slider({ticks:[0,1,2,3,4],ticks_positions:[0,30,60,70,90,100],ticks_snap_bounds:200,formatter:function(value){return'Current value: '+ value;},ticks_tooltip:true,step:0.01});//#ex5
var slider=new Slider('#ex5');$("#destroyEx5Slider").on('click',function(){$("#ex5").slider('destroy');slider.destroy();});//#7
var slider=new Slider("#ex7");$("#ex7-enabled").on('click',function(){if(this.checked){$("#ex7").slider("enable");slider.enable();}else{$("#ex7").slider("disable");slider.disable();}});});