export interface Asset {
    id: string;
    name: string;
    description: string;
    price: number;
    createdAt: string;
    lastUpdatedAt: string;
    keywords: string[];
    comments: AssetComment[];
    authorId: string;
    tombstoned: boolean;
    version: number;
    blobUri: string;
    fileSizeBytes: number;
    checksum: string;

    // TODO: Remove these later. These are only used by the front page mock data.
    featured?: boolean;
    rating?: number;
    reviews?: number;
    author?: string;
    title?: string;
    image?: string;
}

export interface AssetComment {
}