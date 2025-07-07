import axios from "axios";
import type { ReviewCreateDto, ReviewDto } from "../types/content";

const BASE_URL = "https://localhost:7084/api/Review";

export const postReview = async ({
  contentId,
  rating,
}: ReviewCreateDto): Promise<void> => {
  await axios.post(
    `${BASE_URL}`,
    { contentId, rating },
    {
      headers: {
        Key: "Key",
      },
    }
  );
};

export const GetReviewsByContentId = async (
  contentId: string
): Promise<ReviewDto[]> => {
  const res = await axios.get(`${BASE_URL}/${contentId}`);

  return res.data;
};
