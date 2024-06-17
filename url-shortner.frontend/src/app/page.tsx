"use client"

import Image from "next/image";
import React, { useState, useEffect } from "react";

export default function Home() {
  const [data, setData] = useState();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5120/RsgNl")
        const result = await response.json();
        console.log(result);
        setData(result);
      } catch (error) {
        console.error("Errro fetching data...", error);
      };
    };

    fetchData();
  }, []);

  return (
    <>
      <h1>Wilkommen</h1>
      {data && <pre>{JSON.stringify(data, null, 2)}</pre>}
    </>
  );
}
