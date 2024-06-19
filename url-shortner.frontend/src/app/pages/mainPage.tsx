"use client"

import React, { useState, useEffect } from "react";
import { Button, Card } from "@nextui-org/react";
import { Input } from "@nextui-org/react";
import { Console } from "console";

export default function MainPage() {
    const [originalUrl, SetOriginalUrl] = useState<string>("");
    const [shortenUrl, SetShortenUrl] = useState<string>("");

    async function GetShortenUrl() {
        try {
            var response = await fetch("http://localhost:5120/short?fullUrl=" + originalUrl, { method: "POST" })
            const shortenUrl = await response.json()
            console.log(shortenUrl)
            SetShortenUrl(shortenUrl.fullShortenUrl)
        } catch (error) {
            console.error("Errro fetching data...", error);
        }
    }

    return (
        <>
            <div className="flex">
                <Input type="text" placeholder="https://www.example.com" onValueChange={SetOriginalUrl} />
                <Button color="primary" onClick={GetShortenUrl}>
                    Get shorten URL
                </Button>
            </div>
            <div>
                <p>original URL:</p>
                {originalUrl}
            </div>
            <div>
                <p>shorten URL:</p>
                <Input
                    isReadOnly
                    type="text"
                    value={shortenUrl}>
                </Input>
            </div>
        </>
    );
}
