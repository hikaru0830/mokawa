import { useSelector } from 'react-redux';
import { Swiper, SwiperSlide } from 'swiper/react';
import { Navigation, Pagination, Autoplay, EffectFade } from 'swiper/modules';

// 引入 Swiper 樣式
import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';
import 'swiper/css/effect-fade';

const images = import.meta.glob('@/assets/banners/May26/*.{png,jpg,jpeg,webp,svg}', { 
  eager: true,
  import: 'default' 
});
// 2. 將物件轉換成純網址陣列
const bannerImages = Object.values(images);

function App() {
    let navHeight = useSelector(state => state.navHeight?.height) || 0;
    return (
      <div>
        <div style={{ '--navh': `${navHeight}px` }}
            className="w-full h-[calc(100vh-var(--navh))]">
            <ImgSwiper navHeight={navHeight} />
        </div>
      </div>
    )
}

function ImgSwiper({navHeight}) {
    return (
    <div className="w-full h-full"> {/* 設定 Banner 高度 */}
      <Swiper
        modules={[Navigation, Pagination, Autoplay, EffectFade]}
        spaceBetween={0}        // 圖片間距
        slidesPerView={1}       // 一次顯示一張
        effect={"fade"}           // 轉場效果：淡入淡出 (比左右滑動更高級)
        loop={true}             // 循環播放
        autoplay={{
          delay: 4000,          // 4秒切換一次
          disableOnInteraction: false,
        }}
        pagination={{ clickable: true }} // 點擊圓點切換
        navigation={true}       // 顯示左右箭頭
        className="w-full h-full"
      >
        {bannerImages.map((src, index) => (
          <SwiperSlide key={index}>
            <div className="w-full h-full relative">
              <img 
                src={src} 
                className="w-full h-full object-cover" 
                alt={`Slide ${index + 1}`} 
              />
            </div>
          </SwiperSlide>
        ))}
      </Swiper>
    </div>
  );
}
export default App