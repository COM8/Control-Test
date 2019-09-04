# The following lines of boilerplate have to be in your project's CMakeLists
# in this exact order for cmake to work correctly
cmake_minimum_required(VERSION 3.10)

set(CMAKE_CXX_STANDARD 17)

include($ENV{IDF_PATH}/tools/cmake/project.cmake)

# Include Smooth as a component
set(EXTRA_COMPONENT_DIRS externals/smooth/smooth_component)

project(gatt_server_service_table_demo)
