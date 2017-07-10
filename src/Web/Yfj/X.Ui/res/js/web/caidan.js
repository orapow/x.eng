// JavaScript Document
//菜单的js代码

$(function(){
$("input.anniu").click(function(){
			$(".comyincang").toggleClass("comyincang_1");

	})	
	
	$(".nav ul li").click(
            function () {
            $(this).toggleClass("active").siblings("li").removeClass("active");
           }
        );
//	$("input.quxiao").click(function(){
//			$(".yincang").hide();
//	})
//	   	$(".yincang").hide();
//		$(".shuai").click(function(){
//			$(".yincang").show();
//	})
//	
	$(".biaoqian").click(function(){
				$(this).next(".fenlei1").toggleClass("fenlei1_1").siblings(".fenlei1").removeClass("fenlei1_1");
	})
	$(".biaoqian01").click(function(){
				$(this).next(".fenlei101").toggleClass("fenlei1_101").siblings(".fenlei101").removeClass("fenlei1_101");
	})
	$(".biaoqian02").click(function(){
				$(this).next(".fenlei102").toggleClass("fenlei1_102").siblings(".fenlei102").removeClass("fenlei1_102");
	})
	
	//$("#box01 ul li a").hover(function(){
//			$(".daoh ul li a").toggleClass("active");
//
//	})	
})

$(function ()

{
    $(".daoh li").mouseover(function (e)
    {

        $(this).find("a").addClass("active");
        $(this).find(".erji").show();
		$(this).find(".erji").find("a").removeClass("active")
    }
    );

    $(".daoh li").mouseout(function (e)
    {

        $(this).find("a").removeClass("active");
        $(this).find(".erji").hide();
    }
    );

//产品详情增加红框代码
    $("#showArea img").click(function ()
    {

        $(this).parent("a").siblings("a").find("img").removeClass("red1");
        $(this).addClass("red1");
    }
    )
    //产品详情增加红框代码
    $("ul.liebiao14 li img").click(function ()
    {

        $(this).parent("li").siblings("li").find("img").removeClass("img_1");
        $(this).toggleClass("img_1");

        $("#zoom1 img").attr("src", $(this).attr("src"));

        $(this).siblings("span.biaoji4").toggle().parents().siblings().find("span.biaoji4").hide();

    }
    )
 //*********************产品详情规格效果*****************************
    $("ul.liebiao15 li").click(function ()
    {
        $(this).toggleClass("show").siblings().removeClass("show");

    }
    )

    $(".fapiao .hd li").click(function ()
    {
        var gao1 = $(".yin5").height();
        $(".yin5").css(
        {
            "margin-top" : -gao1 / 2 + "px",
            "top" : "50%"
        }
        );
        if (gao1 > 500)
        {
            $(".yin5").css(
            {
                "margin-top" : "0px",
                "top" : "0px"
            }
            );

        }

    }
    )
    $("input.close2").click(function ()
    {
        $(this).parents(".big26").hide();

    })
	
$('.gou1').click(function(){//单击ID为#login的A标签
		$('.qdin').fadeIn();//名为#login_box的DIV显示,时间为1000毫秒=1秒
		$('.beij').fadeIn();//名为#mask的DIV显示
		})
	$('.cha').click(function(){
		$('.qdin').fadeOut();//名为#login_box的DIV隐藏
		$('.beij').fadeOut();//名为#mask的DIV隐藏
		})	
	$('.btn01').click(function(){
		$('.qdin').fadeOut();//名为#login_box的DIV隐藏
		$('.beij').fadeOut();//名为#mask的DIV隐藏
		})		
	
}
)
  