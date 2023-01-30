function GetWish() {
    let wishlist = JSON.parse(localStorage.getItem('wishlist'));
let item = ''
wishlist.forEach(x => {
    item += `
    <div class="col-lg-12 ado list-wish">
    <a href="/shop-detail.html"><img src="${x.Image}" alt=""></a>
    <h2 class="cc product-name">${x.Name}</h2>
    <input type="number" value=${x.Count}>
    <h3 class="product-price">$ ${x.Price}</h3>
    </div>
    `
})
document.getElementById('wish-list').innerHTML = item
}

GetWish()


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

function Calcultor() {
    let wishlist = JSON.parse(localStorage.getItem('wishlist'));
    let AllPrice=0;
    let AllCount=0;
      wishlist.forEach(x => {
           let Price=parseFloat(x.Price);
           let FullPrice=x.Count*Price;
           AllPrice+=FullPrice;
           AllCount+=x.Count;
      });
         
         let items="";

         items=`
         <div class="wishlist-box w-100 mx-auto  col-lg-12 d-flex align-items-center justify-content-between">
         <h4 class="allcount">AllCount:${AllCount}</h4>
         <h4 class="allprice">AllPrice:${AllPrice}</h4>
     </div>
    
         `
         document.getElementById('calcu').innerHTML = items;
            

}
Calcultor();