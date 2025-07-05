import axios from "axios";
import type { ContentDto, ContentType } from "../types/content";

const BASE_URL = "https://localhost:7084/api/Content";

export const getAllContent = async (): Promise<ContentDto[]> => {
  const res = await axios.get(BASE_URL);
  return res.data;
};

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

export const getContentById = async (id: string): Promise<ContentDto> => {
  const res = await axios.get(`${BASE_URL}/${id}`);
  return res.data;
};

export const getContentByTitle = async (title: string): Promise<ContentDto> => {
  const res = await axios.get(`${BASE_URL}/${title}`);
  return res.data;
};

export const getContentByType = async (
  type: ContentType
): Promise<ContentDto> => {
  const res = await axios.get(`${BASE_URL}/${type}`);
  return res.data;
};
