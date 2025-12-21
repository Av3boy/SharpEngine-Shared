
import { Asset } from "../../../types/asset";
import { AssetCard } from "../../../components/AssetCard";

interface ProfileAsset {
  id: string;
  title: string;
  type: string;
  imageUrl: string;
  publishedDate: string;
  downloads: number;
  likes: number;
}

const mockAssets: ProfileAsset[] = [
  {
    id: '1',
    title: 'Modern Dashboard UI Kit',
    type: 'UI Kit',
    imageUrl: 'https://images.unsplash.com/photo-1625009431843-18569fd7331b?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxkZXNpZ24lMjBtb2NrdXB8ZW58MXx8fHwxNzY1NzM1MzcyfDA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral',
    publishedDate: '2024-11-20',
    downloads: 1243,
    likes: 456,
  },
  {
    id: '2',
    title: 'Web Application Components',
    type: 'Component Library',
    imageUrl: 'https://images.unsplash.com/photo-1704699175212-117f10d5b3b4?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHx3ZWIlMjBpbnRlcmZhY2V8ZW58MXx8fHwxNzY1NzM1MzczfDA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral',
    publishedDate: '2024-12-05',
    downloads: 892,
    likes: 312,
  },
  {
    id: '3',
    title: 'Mobile App Design System',
    type: 'Design System',
    imageUrl: 'https://images.unsplash.com/photo-1609921212029-bb5a28e60960?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxtb2JpbGUlMjBhcHAlMjBkZXNpZ258ZW58MXx8fHwxNzY1NzE5MzgzfDA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral',
    publishedDate: '2024-12-12',
    downloads: 567,
    likes: 234,
  },
];

function toSharedAsset(a: ProfileAsset): Asset {
  return {
    id: a.id,
    title: a.title,
    name: a.title,
    description: `${a.type} asset published on ${a.publishedDate}`,
    image: a.imageUrl,
    author: "You",
    price: 0,
    createdAt: a.publishedDate,
    lastUpdatedAt: a.publishedDate,
    keywords: [a.type],
    comments: [],
    authorId: "",
    tombstoned: false,
    version: 1,
    blobUri: "",
    fileSizeBytes: 0,
    checksum: "",
    featured: false,
    rating: Math.min(5, Math.max(0, a.likes / 100)),
    reviews: a.likes,
  };
}

export function AssetsTab() {
  return (
    <div className="max-w-6xl mx-auto p-8" style={{paddingTop: '0'}}>
      <div className="flex items-center gap-3 mb-6">
        {/*<FileImage className="w-6 h-6 text-blue-600" />*/}
        <h2 className="text-2xl font-semibold">Published Assets</h2>
        <span className="text-gray-500">({mockAssets.length} assets)</span>
      </div>
      
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
        {mockAssets.map((a) => (
          <AssetCard key={a.id} asset={toSharedAsset(a)} />
        ))}
      </div>
    </div>
  );
}
