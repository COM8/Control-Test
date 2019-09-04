cmake_minimum_required(VERSION 3.10)

set(CMAKE_CXX_STANDARD 17)

set(SOURCES "gatts_table_creat_demo.c")

idf_component_register(SRCS ${SOURCES}
                       INCLUDE_DIRS ${CMAKE_CURRENT_LIST_DIR} $ENV{IDF_PATH}/components
                       REQUIRES smooth_component)
        