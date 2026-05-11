import './components.css'
import { CategoriesL } from '../data/data.js'
import Mokawa from '../assets/mokawa.svg'

import { Input } from "@/components/ui/input"
import { Search, ShoppingCart, CircleUserRound} from "lucide-react";

function App() {
    return (
        <>
        <nav className="p-[20px] flex items-center">
            <img src={Mokawa} alt="logo" />
            <div className="category-container grow-1 ms-10">
                <ul className="flex items-center gap-10">
                    <li><a href="#">HOME</a></li>
                    {
                        CategoriesL.map(category => {
                            return <li key={category}><a href="#">{category}</a></li>
                        })
                    }
                </ul>
            </div>
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
        </nav>
        </>
    );
}

export default App;