import axios from "axios";
import type { ContentDto, ContentType } from "../types/content";

const BASE_URL = "https://localhost:7084/api/Content";

export const getContentByTypePaginated = async (
  type: ContentType,
  page: number,
  pageSize: number
): Promise<ContentDto[]> => {
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
  releaseDate?: string
): Promise<ContentDto[]> => {
  const params: any = {};
  if (title && title.length >= 2) params.title = title;
  if (releaseDate) params.releaseDate = releaseDate;

  const res = await axios.get(`${BASE_URL}/search`, {
    params,
  });

  return res.data;
};
