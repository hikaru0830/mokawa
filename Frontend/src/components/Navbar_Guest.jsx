import './components.css'
import { useEffect, useRef } from 'react';
import { useDispatch } from 'react-redux';
import { CategoriesL } from '../data/data.js'
// import Mokawa from '../assets/mokawa.svg'
import Mokawa from '../assets/mkw.svg'

import { Input } from "@/components/ui/input"
import { Search, ShoppingCart, CircleUserRound} from "lucide-react";
import { setNavHeight } from '@/slices/navHeightSlice.js'

function App() {
    const navRef = useRef(null);
    const dispatch = useDispatch();

    useEffect(() => {
        if (!navRef.current) return;

        const resizeObserver = new ResizeObserver((entries) => {
            entries.forEach(entry => {
                if (entry.target == navRef.current) {
                    dispatch(setNavHeight(entry.target.offsetHeight));
                }
            });
        });

        resizeObserver.observe(navRef.current);

        return () => resizeObserver.disconnect();
    }, [dispatch]);

    return (
        <>
        <nav ref={navRef} className="px-[20px] py-[10px] shadow-md">
            <div className="flex items-center justify-center">
                <img src={Mokawa} alt="logo" />
            </div>
            <hr className="my-[10px]"/>
            <div className="category-container flex items-center justify-between">
                <ul className="flex items-center gap-10">
                    {
                        CategoriesL.map(category => {
                            return <li key={category.id}><a href="#">{category.text}</a></li>
                        })
                    }
                </ul>
                <div className="function-container flex items-center gap-4">
                    <div className="flex items-center gap-2">
                        <Input
                            className={"rounded-xs"}
                            showFocusStyle={false}
                            placeholder="請輸入關鍵字" />
                        <Search className="text-neutral-600 cursor-pointer"
                            onClick={() => {console.log("!")}}/>
                    </div>
                    <ShoppingCart className="text-neutral-600 cursor-pointer"
                        onClick={() => {console.log("!")}}/>
                    <CircleUserRound className="text-neutral-600 cursor-pointer"
                        onClick={() => {console.log("!")}}/>
                </div>
            </div>
        </nav>
        </>
    );
}

export default App;