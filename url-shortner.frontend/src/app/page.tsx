"use client"

import { NextUIProvider } from "@nextui-org/react"
import MainPage from "./pages/mainPage";

export default function Home() {

  return (
    <NextUIProvider>
      <MainPage></MainPage>
    </NextUIProvider>
  );
}
