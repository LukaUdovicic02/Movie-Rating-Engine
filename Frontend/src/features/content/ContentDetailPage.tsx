import { Link, useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { GetReviewsByContentId, postReview } from "../../api/reviewApi";
import type { ContentDetailDto, ReviewDto } from "../../types/content";
import { getContentById } from "../../api/contentApi";

const ContentDetailPage = () => {
  const { id } = useParams<{ id: string }>();
  const [content, setContent] = useState<ContentDetailDto | null>(null);
  const [reviews, setReviews] = useState<ReviewDto[]>([]);
  const [rating, setRating] = useState<number>(1); 

  useEffect(() => {
    if (!id) return;

    getContentById(id).then(setContent);
    GetReviewsByContentId(id).then(setReviews);
  }, [id]);

  const handleReviewSubmit = async () => {
    if (!id || rating < 1 || rating > 5) return;

    try {
      await postReview({ contentId: id, rating });
      const updatedReviews = await GetReviewsByContentId(id);
      setReviews(updatedReviews);
    } catch (err) {
      console.error("Failed to submit review:", err);
    }
  };

  if (!content) return <p>Loading...</p>;

  return (
    <div className="p-8 max-w-4xl flex flex-col items-center mx-auto">
      <img
        src={content.imageURL}
        alt={content.title}
        className="w-52 h-64 object-fill rounded-md mb-4"
      />
      <h1 className="text-3xl font-bold">{content.title}</h1>
      <p className="text-gray-700 mt-2">{content.description}</p>
      <p className="text-sm text-gray-500">
        Release Date: {new Date(content.releaseDate).toDateString()}
      </p>
      <p className="text-sm text-gray-500">
        Average Rating: ⭐ {content.averageRating.toFixed(1)}
      </p>

      <h2 className="text-xl font-semibold mt-6">Cast</h2>
      <ul className="list-disc mt-2 list-inside">
        {content.casts.map((actor) => (
          <li key={actor.id}>{actor.name}</li>
        ))}
      </ul>

      <h2 className="text-xl font-semibold mt-6">Reviews</h2>
      <ul className="mt-2">
        {reviews.map((review) => (
          <li key={review.id}> {review.rating} ⭐</li>
        ))}
      </ul>

      
      <div className="mt-8 w-64 text-center">
        <label className="block mb-2 font-medium">Leave a Rating:</label>
        <select
          className="w-full px-4 py-2 border mt-2 mb-2 rounded shadow "
          value={rating}
          onChange={(e) => setRating(Number(e.target.value))}
        >
          {[1, 2, 3, 4, 5].map((num) => (
            <option key={num} value={num}>
                {num} ⭐
            </option>
          ))}
        </select>
        <button
          onClick={handleReviewSubmit}
          className="mt-4 bg-gray-600 text-white px-4 py-2 rounded hover:bg-gray-400 transition"
        >
          Submit Review
        </button>
      </div>

      <div className="flex justify-center gap-4 mt-8">
        <Link to={`/`}>
          <button className="bg-gray-300 px-4 py-1.5 rounded-md shadow-lg hover:bg-gray-200 border border-gray-100 transition duration-500 w-24">
            Back
          </button>
        </Link>
      </div>
    </div>
  );
};

export default ContentDetailPage;
