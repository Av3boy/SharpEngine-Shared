import { useNavigate } from "react-router-dom";
import { Asset } from "../types/asset";
import StarIcon from '@mui/icons-material/Star';

interface AssetCardProps {
  asset: Asset;
}

export function AssetCard({ asset }: AssetCardProps) {
    const navigate = useNavigate();
  const title = asset.title || asset.name || `Asset ${asset.id}`;
  const image = asset.image || asset.blobUri || "";
  const author = asset.author || "Unknown";
  const keywords = Array.isArray(asset.keywords) ? asset.keywords.slice(0, 3) : [];
  const rating = typeof asset.rating === "number" ? asset.rating : 0;
  const reviews = typeof asset.reviews === "number" ? asset.reviews : 0;
  const price = typeof asset.price === "number" ? asset.price : 0;
  const featured = !!asset.featured;

  return (
    <div className="bg-white rounded-lg overflow-hidden shadow-md hover:shadow-xl transition-shadow cursor-pointer group"
        style={{cursor: 'pointer'}}
        onClick={() => navigate(`http://localhost:3001/assets/${asset.id}`)}>
      {/* Image */}
      <div className="relative aspect-video overflow-hidden bg-gray-100">
        {image ? (
          <img
            src={image}
            alt={title}
            className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-300"
          />
        ) : (
          <div className="w-full h-full flex items-center justify-center text-gray-400">
            No image
          </div>
        )}
        {featured && (
          <div className="absolute top-2 right-2 bg-yellow-400 text-gray-900 px-2 py-1 rounded text-xs">
            Featured
          </div>
        )}
      </div>

      {/* Content */}
      <div className="p-4">
        <h3 className="text-gray-900 mb-1 truncate">{title}</h3>
        <p className="text-sm text-gray-500 mb-3">by {author}</p>

        {/* Keywords */}
        {keywords.length > 0 && (
          <div className="flex flex-wrap gap-1 mb-3">
            {keywords.map((keyword) => (
              <span key={keyword} className="text-xs bg-gray-100 text-gray-600 px-2 py-1 rounded">
                {keyword}
              </span>
            ))}
          </div>
        )}

        {/* Footer */}
        <div className="flex items-center justify-between">
          <div className="flex items-center gap-1">
            <StarIcon fontSize="small" style={{ color: '#f59e0b' }} />
            <span className="text-sm text-gray-700">{rating.toFixed(1)}</span>
            <span className="text-sm text-gray-400">({reviews})</span>
          </div>
          <span className="text-indigo-600">${price.toFixed(2)}</span>
        </div>
      </div>
    </div>
  );
}
