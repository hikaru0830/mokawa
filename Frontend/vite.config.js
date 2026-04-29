import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import path from 'path'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    port: 5173,
    strictPort: true,
    cors: true,
    origin: 'http://localhost:5173',
    proxy: {
      '/api': {
        target: 'http://localhost:7000',
        changeOrigin: true,
        secure: false,
      }
    }
  },
  build: {
    manifest: true,
    // 1. 設定輸出路徑到後端的 wwwroot 下的某個資料夾 (例如 dist)
    outDir: path.resolve(__dirname, '../Mkw/wwwroot/dist'),
    emptyOutDir: true, // 每次打包先清空舊檔
    // rollupOptions: {
    //   output: {
    //     // 2. 固定檔名，避免每次打包 Hash 碼變動導致 Razor 找不到檔案
    //     entryFileNames: `assets/[name].js`,
    //     chunkFileNames: `assets/[name].js`,
    //     assetFileNames: `assets/[name].[ext]`
    //   }
    // }
  }
})
