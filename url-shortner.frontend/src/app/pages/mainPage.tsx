"use client"

import React, { useState, useEffect } from "react";
import { Button, Card } from "@nextui-org/react";
import { Input } from "@nextui-org/react";
import { ApiService } from "../services/ApiService";

export default function MainPage() {
    const [originalUrl, SetOriginalUrl] = useState<string>("");
    const [shortenUrl, SetShortenUrl] = useState<string>("");
    const apiService = new ApiService()

    async function GetShortenUrl() {
        const url = await apiService.GetShortenUrl(originalUrl);
        console.log("url", url);
        SetShortenUrl(url);
    }

    return (
        <>
            <div className="grid grid-col-2 gap-1 justify-stretch">
                <div className="col-start-1 col-end-1 grid grid-col-2">
                    <Input type="text" placeholder="https://www.example.com" onValueChange={SetOriginalUrl} />
                    <Button color="primary" onClick={GetShortenUrl}>
                        Get shorten URL
                    </Button>
                </div>

                <div className="col-start-2 col-end-2">
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
                </div>
            </div>
        </>
    );
}
