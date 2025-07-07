import axios from "axios";
import type {
  ContentDetailDto,
  ContentDto,
  ContentType,
} from "../types/content";

const BASE_URL = "https://localhost:7084/api/Content";

export const getContentByTypePaginated = async (
  type: ContentType,
  page: number,
  pageSize: number
): Promise<ContentDetailDto[]> => {
  const res = await axios.get(`${BASE_URL}/type`, {
    params: {
      type,
      page,
      pageSize,
    },
  });

  return res.data;
};

export const searchContent = async (
  title?: string,
  releaseDate?: string,
  minRating?: number
): Promise<ContentDetailDto[]> => {
  const params: any = {};
  if (title && title.length >= 2) params.title = title;
  if (releaseDate) params.releaseDate = releaseDate;
  if (minRating) params.minRating = minRating;

  const res = await axios.get(`${BASE_URL}/search`, {
    params,
  });

  return res.data;
};

export const getContentById = async (
  contentId: string
): Promise<ContentDetailDto> => {
  const res = await axios.get(`${BASE_URL}/${contentId}`);

  return res.data;
};
