






  $('.slider').slick({
    dots:false,
    infinite: true,
    speed: 300,
    slidesToShow: 1,
    autoplay:true,
    
    autoplaySpeed:2000,
    
    slidesToScroll: 1,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 3,
          infinite: true,
         
          dots:false,
        }
      },
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
          
        }
      }
     
    ]
  });








  $('.category-slider').slick({
    dots:false,
    infinite: true,
    speed: 300,
    slidesToShow: 4,
    autoplay:true,
    
    autoplaySpeed:1000,
    
    slidesToScroll: 1,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
         
          dots:false,
        }
      },
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 1
        }
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
          
        }
      }
     
    ]
  });

  $('.testimonial-slider').slick({
    dots:false,
    infinite: true,
    speed: 300,
    slidesToShow: 1,
    autoplay:true,
    
    autoplaySpeed:1000,
    
    slidesToScroll: 1,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 3,
          infinite: true,
         
          dots:false,
        }
      },
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
          
        }
      }
     
    ]
  });

  $('.trending-slider').slick({
    dots:false,
    infinite: true,
    speed: 300,
    slidesToShow: 4,
    autoplay:true,
    
    autoplaySpeed:1000,
    
    slidesToScroll: 1,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
         
          dots:false,
        }
      },
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 1
        }
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
          
        }
      }
     
    ]
  });

  $('.blog-slider').slick({
    dots:false,
    infinite: true,
    speed: 300,
    slidesToShow: 4,
    autoplay:true,
    
    autoplaySpeed:1000,
    
    slidesToScroll: 1,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
         
          dots:false,
        }
      },
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 1
        }
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
          
        }
      }
     
    ]
  });


  $(window).on("scroll", function (event) {
    if ($(this).scrollTop() > 600) {
        $(".scrl").css("opacity","0.7");
    } else {
      $(".scrl").css("opacity","1");
  
    }
  });
  

  






if(localStorage.getItem('wishlist') === null) {
  localStorage.setItem('wishlist',JSON.stringify([]))
}

function CountWishlist() {
let wishlist = JSON.parse(localStorage.getItem('wishlist'));
if(wishlist.length === 0 ) {
    document.getElementById('count-wishlist').style.display = 'none'
}
else{
    document.getElementById('count-wishlist').style.display = 'block'
}
document.getElementById('count-wishlist').innerHTML = wishlist.length
}

CountWishlist()

let btnw = document.getElementsByClassName('btnw_add');

setTimeout(() => {
for(let btn of btnw) {
    btn.onclick = function(e) {
        let wishlist = JSON.parse(localStorage.getItem('wishlist'))
        let id = e.target.parentElement.parentElement.parentElement.parentElement.parentElement.id;
        console.log(id);
        let price = e.target.parentElement.parentElement.parentElement.parentElement.parentElement.children[1].children[1].children[0].innerHTML;
        price=Number.parseInt(price.slice(1));
        console.log(price);
        let title = e.target.parentElement.parentElement.parentElement.parentElement.parentElement.children[1].children[0].children[0].innerHTML;
        console.log(title);
        let image = e.target.parentElement.parentElement.parentElement.parentElement.parentElement.children[0].children[0].children[0].src ;
          console.log(image);
        let existProd = wishlist.find(x => x.Id == id);
        let filter = wishlist.filter(x => x.Id != id);
       
        if(existProd == undefined) {
          wishlist.push({
                Id: id,
                Name: title,
                Price: price,
                Image: image,
                Count: 1
            })
        }
        else{
            existProd.Count += 1;
        }

        

        localStorage.setItem('wishlist',JSON.stringify(wishlist));
         CountWishlist();
    }
}
}, 1000);






$(window).on("scroll", function (event) {
  if ($(this).scrollTop() > 600) {
      $(".back-to-top").css("opacity","1");
  } else {
    $(".back-to-top").css("opacity","0");

  }
});



